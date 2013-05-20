using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rosalyna.Core
{
    public class TraceMethodExecutionRewriter : SyntaxRewriter
    {
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var trace = String.Format("System.Diagnostics.Trace.TraceInformation(\"rosalyning : Called method {0};\")", node.Identifier.ValueText);
            var traceStatement = Syntax.ParseStatement(trace);

            var statements = new SyntaxList<StatementSyntax>()
                        .Add(traceStatement)
                        .Add(node.Body.Statements.Cast<StatementSyntax>().ToArray());

            var result = (MethodDeclarationSyntax) base.VisitMethodDeclaration(node);
            var body = node.Body.Update(Syntax.Token(SyntaxKind.OpenBraceToken), statements, Syntax.Token(SyntaxKind.CloseBraceToken));

            return result.WithBody(body);
        }
    }
}
