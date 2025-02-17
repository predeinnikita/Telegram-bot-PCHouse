﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRTF_bot.model;
using TestRTF_bot.model.Components;

namespace TestRTF_bot.Models.Accessories
{
    class Motherboard : IComponent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Rating { get; set; }
        public string Socket { get; set; }
        public string RAM { get; set; }
        public int RAMFrequency { get; set; }
        public string RAMTimings { get; set; }
        public string ARRAY_ProcessorCoolings { get; set; }
        public string ARRAY_CaseCoolings { get; set; }
        public int SataInterfaceCount { get; set; }
        public int M2Length { get; set; }
        public string FormFactor { get; set; }
        public string PinPowerCP { get; set; }
        public int CoolerHeight { get; set; }
        public int CoolerWidth { get; set; }
        public int CoolerLength { get; set; }

        public bool IsCompatible(IComponent otherComponent)
        {
            if (otherComponent is Processor cpu)
                return cpu.Socket.ToLower() == Socket.ToLower();
            if (otherComponent is RAM ram)
                return ram.Frequency <= RAMFrequency;
            if (otherComponent is M2 m2)
                return m2.Length <= M2Length;
            if (otherComponent is Case computerCase)
                return computerCase.GetFormFactors().Any(x => x.ToLower() == FormFactor.ToLower());
            if (otherComponent is ProcessorCooling cpuFans)
                return cpuFans.Socket.Split(", ").Any(x => x.ToLower() == Socket.ToLower());
            if (otherComponent is PowerModule powerModule)
                return powerModule.PinPowerCP.ToLower() == PinPowerCP.ToLower()
                    && powerModule.SataCount >= SataInterfaceCount;
            return true;
        }

        public string[] GetProcessorCoolings() => ARRAY_ProcessorCoolings.GetArray();

        public string[] GetCaseCoolings() => ARRAY_CaseCoolings.GetArray();
    }
}
