using System;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace AudioHotkeySoundboard
{
  static class Program
  {
    private static Mutex mutex = null;

    [STAThread]
    static void Main()
    {
      const string appName = "AudioHotkeySoundboard";
      bool createdNew;

      mutex = new Mutex(true, appName, out createdNew);

      if (!createdNew)
      {
        return;
      }

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Load NAudio from embedded resources
      AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
        string resourceName = new AssemblyName(args.Name).Name + ".dll";
        string resource = Array.Find(typeof(MainForm).Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
        {
          Byte[] assemblyData = new Byte[stream.Length];
          stream.Read(assemblyData, 0, assemblyData.Length);
          return Assembly.Load(assemblyData);
        }
      };
      Application.Run(new MainForm());
    }
  }
}
