﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tracer
{
    public class ThreadInfo
    {
        
        private readonly Stack<MethodInfo> methodsCallStack;
        private readonly List<MethodInfo> firstNestingLevelTracedMethods;

        public ThreadInfo()
        {
            firstNestingLevelTracedMethods = new List<MethodInfo>();
            methodsCallStack = new Stack<MethodInfo>();
        }

        public long ExecutionTime => firstNestingLevelTracedMethods.Sum((method) => method.ExecutionTime);

        public IEnumerable MethodsInfo => firstNestingLevelTracedMethods;

        internal void StartMethodTrace(MethodInfo methodInfo)
        {
            if (methodsCallStack.Count == 0)
            {
                firstNestingLevelTracedMethods.Add(methodInfo);
            }
            else
            {
                MethodInfo lastAddedMethod = methodsCallStack.Peek();
                lastAddedMethod.AddChild(methodInfo);
            }

            methodsCallStack.Push(methodInfo);
        }

        internal void StopMethodTrace(MethodInfo methodInfo)
        {
            if (methodsCallStack.Count == 0)
            {
                throw new Exception("There are no MethodsInfo in stack. Maybe you have called StopTrace twice");
            }

            MethodInfo lastAddedMethod = methodsCallStack.Pop();
            lastAddedMethod.StopMethodTrace();
        }
    }
}
