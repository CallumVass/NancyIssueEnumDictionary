using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Hosting.Self;

namespace NancyIssueEnumDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:1235")))
            {
                host.Start();
                Console.ReadLine();
            }
        }
    }

    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            // wont work
            Get["/test"] = _ =>
            {
                var data = new ResponseObject {Name = "Test"};

                data.Dictionary.Add(MyEnum.Test, "Test");

                return data;
            };

            // will work
            Get["/test2"] = _ =>
            {
                var data = new ResponseObject {Name = "Test 2"};
                return data;
            };
        }
    }

    public class ResponseObject
    {
        public string Name { get; set; }
        public Dictionary<MyEnum, string> Dictionary { get; set; }

        public ResponseObject()
        {
            Dictionary = new Dictionary<MyEnum, string>();
        }
    }

    public enum MyEnum
    {
        Test,
        TestTwo
    }
}
