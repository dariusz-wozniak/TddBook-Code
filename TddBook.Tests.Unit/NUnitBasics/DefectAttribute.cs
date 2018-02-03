using System;
using NUnit.Framework;

namespace TddBook.Tests.Unit.NUnitBasics
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DefectAttribute : CategoryAttribute { }
}