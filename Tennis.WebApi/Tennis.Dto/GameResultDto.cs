using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.Dto
{
    public class GameResultDto
    {
        public string Venue { get; set; }
        public string Surface { get; set; }
        public PlayerDto PlayerOne { get; set; }
        public PlayerDto PlayerTwo { get; set; }
        public string Date { get; set; }
    }
}
