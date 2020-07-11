using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using LUM.Services.Material.Common.Enum;
using LUM.Services.Material.Model.Request;
using Moq;

namespace LUM.Services.Material.Test.Helper
{
    public static class MockHelper
    {
        public static CreateMaterialBindingModel MoqCreateMaterialBindingModel()
        {
            var moq = (new AutoFixture.Fixture()).Create<CreateMaterialBindingModel>();
            moq.FunctionMaxTemperature = 60;
            moq.FunctionMinTemperature = 10;
            return moq;
        }

    }
}
