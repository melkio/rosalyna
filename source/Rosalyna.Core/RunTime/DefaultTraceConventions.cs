using Rosalyna.Core.ComponentModel;
using Roslyn.Compilers.CSharp;
using System;

namespace Rosalyna.Core.RunTime
{
    public class DefaultTraceConventions : ITraceConventions
    {
        public DefaultTraceConventions()
        {
            TraceSyntax = n =>
                                {
                                    var trace = String.Format("System.Diagnostics.Trace.TraceInformation(\"rosalyning : Called method {0};\")", n.Identifier.ValueText);
                                    return Syntax.ParseStatement(trace);
                                };
        }

        public Func<MethodDeclarationSyntax, StatementSyntax> TraceSyntax { get; set; }
    }
}
