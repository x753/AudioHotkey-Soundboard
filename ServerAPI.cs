using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace AudioHotkeySoundboard
{
    class ServerAPI
    {
        public readonly HttpListener _listener;
        private Thread _listenerThread;

        public static MainForm Instance;

        public ServerAPI(MainForm instance)
        {
            Instance = instance;

            Running = false;

            try
            {
                _listener = new HttpListener { IgnoreWriteExceptions = true };
            }
            catch (PlatformNotSupportedException)
            {
                _listener = null;
            }
        }

        public bool PlatformNotSupported
        {
            get {
                return _listener == null;
            }
        }

        public bool StartHttpListener()
        {
            if (PlatformNotSupported)
                return false;

            try
            {
                if (_listener.IsListening)
                {
                    return true;
                }

                string prefix = "http://+:" + 42101 + "/";

                _listener.Prefixes.Clear();
                _listener.Prefixes.Add(prefix);
                _listener.Start();

                Running = true;

                if (_listenerThread == null)
                {
                    _listenerThread = new Thread(HandleRequests);
                    _listenerThread.Start();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool StopHttpListener()
        {
            if (PlatformNotSupported || !Running)
                return false;

            try
            {
                _listenerThread?.Abort();
                _listener.Stop();
                _listenerThread = null;
                Running = false;
                return true;
            }
            catch (HttpListenerException)
            { }
            catch (ThreadAbortException)
            { }
            catch (NullReferenceException)
            { }
            catch (Exception)
            { }
            return true;
        }

        private void HandleRequests()
        {
            while (_listener.IsListening)
            {
                IAsyncResult context = _listener.BeginGetContext(ListenerCallback, _listener);
                context.AsyncWaitHandle.WaitOne();
            }
        }

        private void ListenerCallback(IAsyncResult result)
        {
            HttpListener listener = (HttpListener)result.AsyncState;
            if (listener == null || !listener.IsListening)
                return;

            // Call EndGetContext to complete the asynchronous operation.
            HttpListenerContext context;
            try
            {
                context = listener.EndGetContext(result);
                context.Response.AddHeader("Cache-Control", "no-cache");
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
                context.Response.AddHeader("Access-Control-Allow-Headers", "*");
                context.Response.AddHeader("Access-Control-Allow-Methods", "*");
            }
            catch (Exception)
            {
                return;
            }

            HttpListenerRequest request = context.Request;

            if (request.HttpMethod == "GET")
            {
                if (request.Url.Segments.Length == 0)
                {
                    context.Response.StatusCode = 404;
                    context.Response.Close();
                }
                else
                {
                    switch (request.Url.Segments[1])
                    {
                        case "list":
                            JArray data = GetSound();
                            Stream output = context.Response.OutputStream;
                            byte[] utfBytes = Encoding.UTF8.GetBytes(data.ToString(Formatting.Indented));

                            context.Response.ContentLength64 = utfBytes.Length;
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = 200;

                            output.Write(utfBytes, 0, utfBytes.Length);
                            output.Close();
                            break;

                        case "play/":
                            if (request.Url.Segments.Length == 3)
                            {
                                PlaySound(int.Parse(request.Url.Segments[2]));
                                context.Response.ContentType = "application/json";
                                context.Response.StatusCode = 200;
                            }
                            else
                            {
                                context.Response.StatusCode = 404;
                            }
                            context.Response.Close();
                            break;

                        case "stop":
                            Instance.StopSound_API();
                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = 200;
                            context.Response.Close();
                            break;

                        default:
                            context.Response.StatusCode = 404;
                            context.Response.Close();
                            break;
                    }
                }
            }
            else
            {
                if (request.HttpMethod == "OPTIONS")
                {
                    context.Response.StatusCode = 200;

                }
                else
                {
                    context.Response.StatusCode = 404;
                }
                context.Response.Close();
            }
        }

        public void PlaySound(int sound)
        {
            Instance.PlaySound_API(sound);
        }

        public void Stop()
        {
            Instance.StopSound_API();
        }

        private JArray GetSound()
        {
            JArray json = new JArray();
            var sound = Instance.GetSound_API();

            for (int i = 0; i < sound.Count(); i++)
            {
                JObject jsonNode = new JObject
                {
                    ["id"] = i,
                    ["name"] = sound[i].SoundClips.Remove(sound[i].SoundClips.Length - 4)
                };

                json.Add(jsonNode);
            }

            return json;
        }

        ~ServerAPI()
        {
            if (PlatformNotSupported)
                return;

            StopHttpListener();
            _listener.Abort();
        }

        public void Quit()
        {
            if (PlatformNotSupported)
                return;

            StopHttpListener();
            _listener.Abort();
        }

        public bool Running { get; set; }
    }
}
