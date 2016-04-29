﻿//
//  Instruction.cs
//
//  Author:
//       Benito Palacios Sánchez <benito356@gmail.com>
//
//  Copyright (c) 2015 Benito Palacios Sánchez
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.IO;

namespace Xdelta.Instructions
{
  public abstract class Instruction
  {
    public Instruction(byte sizeInTable, InstructionType type)
    {
      Type = type;
      SizeInTable = sizeInTable;
      Size = sizeInTable;
    }

    public InstructionType Type { get; }

    protected byte SizeInTable { get; }

    public uint Size { get; private set; }

    public abstract void DecodeInstruction(Window window, Stream input, Stream output);

    public void Decode(Window window, Stream input, Stream output)
    {
      if (Type != InstructionType.Noop && SizeInTable == 0)
        Size = window.Instructions.ReadInteger();

      DecodeInstruction(window, input, output);
    }
  }
}