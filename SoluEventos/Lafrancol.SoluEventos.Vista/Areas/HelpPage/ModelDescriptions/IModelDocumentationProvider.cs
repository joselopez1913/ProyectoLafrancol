using System;
using System.Reflection;

namespace Lafrancol.SoluEventos.Vista.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}