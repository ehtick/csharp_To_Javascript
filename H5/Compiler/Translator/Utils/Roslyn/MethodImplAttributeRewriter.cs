using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace H5.Translator
{
    public class MethodImplAttributeRewriter : CSharpSyntaxRewriter, ICSharpReplacer
    {
        private SemanticModel _semanticModel;

        public SyntaxNode Replace(SyntaxNode root, SemanticModel model, SharpSixRewriter rewriter)
        {
            _semanticModel = model;
            return Visit(root);
        }

        public override SyntaxNode VisitAttributeList(AttributeListSyntax node)
        {
            if (node.Attributes.Count > 0)
            {
                var newAttributes = node.Attributes.Where(a => !IsMethodImplAttribute(a));
                if (newAttributes.Count() != node.Attributes.Count)
                {
                    if (!newAttributes.Any())
                    {
                        return null;
                    }
                    return node.WithAttributes(SyntaxFactory.SeparatedList(newAttributes));
                }
            }
            return base.VisitAttributeList(node);
        }

        private bool IsMethodImplAttribute(AttributeSyntax attribute)
        {
            var typeInfo = _semanticModel.GetTypeInfo(attribute.Name);
            var type = typeInfo.Type;

            if (type != null)
            {
                var fullName = type.ToDisplayString();
                if (fullName == "System.Runtime.CompilerServices.MethodImplAttribute")
                {
                    return true;
                }
            }

            return false;
        }
    }
}
