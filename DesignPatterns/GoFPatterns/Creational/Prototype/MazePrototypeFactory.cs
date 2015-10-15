using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFPatterns.Creational.Prototype
{
    class MazePrototypeFactory
    {
        private Door door;
        private Maze maze;

        public MazePrototypeFactory(Maze Maze, Door Door)
        {
            door = Door;
            maze = Maze;
        }

        public Door MakeDoor()
        {
            return (Door)door.Clone();
        }

        public Maze MakeMaze()
        {
            return (Maze)maze.Clone();
        }
    }
}
