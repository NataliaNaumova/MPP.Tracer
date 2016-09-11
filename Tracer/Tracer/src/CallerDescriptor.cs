﻿using System;


namespace Tracer
{
    public class CallerDescriptor
    {
        public String Name { get; private set; }
        public String ClassName { get; private set; }
        public int ParamsNumber { get; private set; }

        public CallerDescriptor(String name, String className, int paramsNumber)
        {
            Name = name;
            ClassName = className;
            ParamsNumber = paramsNumber;
        }

    }
}
