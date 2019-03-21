using System;

namespace Practice7UserList.Tools.Interfaces
{
    internal enum ViewChinaHoroscope
    {
        Monkey,
        Cock,
        Dog,
        Pig,
        Rat,
        Bull,
        Tiger,
        Cat,
        Dragon,
        Snake,
        Horse,
        Goat
    }

    internal interface IChinaHoroscope
    {
        string GiveChinaHoroscope(DateTime? date);
    }
}
