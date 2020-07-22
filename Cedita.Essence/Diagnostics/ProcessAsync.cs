// Copyright (c) Cedita Ltd. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cedita.Essence.Diagnostics
{
    public class ProcessAsync : IDisposable
    {
        private readonly TaskCompletionSource<bool> exited;

        private ProcessAsync(Process process)
        {
            this.Process = process;
            this.exited = new TaskCompletionSource<bool>();
            this.Process.EnableRaisingEvents = true;
            this.Process.Exited += this.OnProcessExited;
            if (this.Process.HasExited)
            {
                this.exited.TrySetResult(false);
            }
        }

        public Process Process { get; }

        public static Task<ProcessAsync> StartAsync(ProcessStartInfo psi)
        {
            return Task.Factory.StartNew(i => new ProcessAsync(Process.Start((ProcessStartInfo)i)), psi);
        }

        public Task WaitForExitAsync() => exited.Task;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> WaitForExitAsync(TimeSpan timeout)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            using CancellationTokenSource cts = new CancellationTokenSource();
            Task exitedTask = this.exited.Task;
            Task completedTask;
            using (cts.Token.Register(o => ((TaskCompletionSource<bool>)o).SetResult(false), tcs))
            {
                cts.CancelAfter(timeout);
                completedTask = await Task.WhenAny(tcs.Task, exitedTask);
            }

            bool result = false;
            if (completedTask == exitedTask)
            {
                await exitedTask;
                result = true;
            }

            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Process.EnableRaisingEvents = false;
                Process.Exited -= this.OnProcessExited;
                exited.TrySetException(new ObjectDisposedException(nameof(ProcessAsync)));
                Process.Dispose();
            }
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            exited.TrySetResult(false);
        }
    }
}
