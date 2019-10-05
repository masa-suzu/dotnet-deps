﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Netsoft.Tools.Deps
{
    public class DotReporter : IProgress<Project>, IProgress<(Project, Project)>, IDisposable
    {
        private readonly TextWriter _writer;
        public DotReporter(TextWriter writer)
        {
            _writer = writer;
            _writer.WriteLine("digraph G {");
        }

        public void Report(Project value)
        {
            _writer.WriteLine($"    \"{value.Name}\"");
        }

        public void Report((Project, Project) value)
        {
            _writer.WriteLine($"    \"{value.Item1.Name}\" -> \"{value.Item2.Name}\"");
        }
        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _writer.WriteLine("}");
                }

                _disposedValue = true;
            }
        }

        // ~DotProgress()
        // {
        //   Dispose(false);
        // }

        public void Dispose()
        {
            Dispose(true);
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
