﻿using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Windows.Forms;
using Action = Microsoft.Win32.TaskScheduler.Action;
using Task = Microsoft.Win32.TaskScheduler.Task;

namespace AudioHotkeySoundboard
{
    internal class StartupManager
    {
        private const string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private bool _startup;

        public StartupManager()
        {
            if (Environment.OSVersion.Platform >= PlatformID.Unix)
            {
                IsAvailable = false;
                return;
            }

            if (IsAdministrator() && TaskService.Instance.Connected)
            {
                IsAvailable = true;

                Task task = GetTask();
                if (task != null)
                {
                    foreach (Action action in task.Definition.Actions)
                    {
                        if (action.ActionType == TaskActionType.Execute && action is ExecAction execAction)
                        {
                            if (execAction.Path.Equals(Application.ExecutablePath, StringComparison.OrdinalIgnoreCase))
                                _startup = true;
                        }
                    }
                }
            }
            else
            {
                try
                {
                    using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(RegistryPath))
                    {
                        string value = (string)registryKey?.GetValue(nameof(AudioHotkeySoundboard));

                        if (value != null)
                            _startup = value == Application.ExecutablePath;
                    }

                    IsAvailable = true;
                }
                catch (SecurityException)
                {
                    IsAvailable = false;
                }
            }
        }

        public bool IsAvailable { get; }

        public bool Startup
        {
            get { return _startup; }
            set {
                if (_startup != value)
                {
                    if (IsAvailable)
                    {
                        if (TaskService.Instance.Connected)
                        {
                            if (value)
                                CreateTask();
                            else
                                DeleteTask();

                            _startup = value;
                        }
                        else
                        {
                            try
                            {
                                if (value)
                                    CreateRegistryKey();
                                else
                                    DeleteRegistryKey();

                                _startup = value;
                            }
                            catch (UnauthorizedAccessException)
                            {
                                throw new InvalidOperationException();
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        private static bool IsAdministrator()
        {
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch
            {
                return false;
            }
        }

        private static Task GetTask()
        {
            try
            {
                return TaskService.Instance.AllTasks.FirstOrDefault(x => x.Name.Equals(nameof(AudioHotkeySoundboard), StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return null;
            }
        }

        private void CreateTask()
        {
            TaskDefinition taskDefinition = TaskService.Instance.NewTask();
            taskDefinition.RegistrationInfo.Description = "Starts AudioHotkeySoundboard on Windows startup.";

            taskDefinition.Triggers.Add(new LogonTrigger());

            taskDefinition.Settings.StartWhenAvailable = true;
            taskDefinition.Settings.DisallowStartIfOnBatteries = false;
            taskDefinition.Settings.StopIfGoingOnBatteries = false;

            taskDefinition.Principal.RunLevel = TaskRunLevel.Highest;
            taskDefinition.Principal.LogonType = TaskLogonType.InteractiveToken;

            taskDefinition.Actions.Add(new ExecAction(Application.ExecutablePath, "", Path.GetDirectoryName(Application.ExecutablePath)));

            TaskService.Instance.RootFolder.RegisterTaskDefinition(nameof(AudioHotkeySoundboard), taskDefinition);
        }

        private static void DeleteTask()
        {
            Task task = GetTask();
            task?.Folder.DeleteTask(task.Name, false);
        }

        private static void CreateRegistryKey()
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(RegistryPath);
            registryKey?.SetValue(nameof(AudioHotkeySoundboard), Application.ExecutablePath);
        }

        private static void DeleteRegistryKey()
        {
            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(RegistryPath);
            registryKey?.DeleteValue(nameof(AudioHotkeySoundboard));
        }
    }
}
