using System;
using TibiaRuneMaker.Logic.Enums;

namespace TibiaRuneMaker.Logic.Interfaces
{
    public interface IClientInjector
    {
        IntPtr SendKey(KeysEnum key);
    }
}