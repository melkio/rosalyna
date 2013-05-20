using Roslyn.Compilers.CSharp;
using System;
namespace Rosalyna.Core.ComponentModel
{
    public interface ITraceConventions
    {
        Func<MethodDeclarationSyntax, StatementSyntax> TraceSyntax { get; set; }
    }
}
