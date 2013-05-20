using NUnit.Framework;
using Rosalyna.Core.RunTime;
using Roslyn.Compilers.CSharp;

namespace Rosalyna.Core.Fixture
{
    [TestFixture]
    public class TraceMethodExecutionRewriterFixture
    {
        [Test]
        public void TryToInjectTraceToMethodWithoutParameters()
        {
            var @class = @"public class MyClass
                            {
                                public void MyMethod()
                                {
                                    var i = 10;
                                    i++;
                                }
                            }";

            var tree = SyntaxTree.ParseText(@class);
            var rewriter = new TraceMethodExecutionRewriter(new DefaultTraceConventions());
            var target = rewriter.Visit(tree.GetRoot());

            var hasBeenInjected = target.ToString().Contains("rosalyning");
            Assert.True(hasBeenInjected);
        }
    }
}
