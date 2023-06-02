using DeathPitTest.MonstersAndHero;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeathPitTest
{
    internal static class CheckIntersectsOfMonsters
    {

        public static void CheckIntersectsOfMonstersByLocation(List<Monster> monsters, PictureBox player, int speed, Timer timer)
        {
            if (timer.Enabled)
            {
                for (var i = 0; i < monsters.Count; i++)
                {
                    var monster = monsters[i];
                    var isIntersectOnY = false;
                    var isIntersectOnX = false;
                    var xMove = speed * (player.Location.X - monster.Location.X) / Math.Sqrt((player.Location.X - monster.Location.X) * (player.Location.X - monster.Location.X) 
                        + (player.Location.Y - monster.Location.Y)*(player.Location.Y - monster.Location.Y));
                    var yMove = speed * (player.Location.Y - monster.Location.Y) / Math.Sqrt((player.Location.X - monster.Location.X) * (player.Location.X - monster.Location.X)
                        + (player.Location.Y - monster.Location.Y) * (player.Location.Y - monster.Location.Y));

                    for (var j = 0; j < monsters.Count; j++)
                    {
                        if (i != j)
                        {
                            if (IsIntersectOnX(monster, monsters[j],  xMove))
                                isIntersectOnX = true;

                            if (IsIntersectOnY(monster, monsters[j],  yMove))
                                isIntersectOnY = true;

                            if (isIntersectOnY && isIntersectOnX)
                                break;
                        }
                    }

                    if (!isIntersectOnX)
                    {
                        monster.Location = new Point(monster.Location.X + (int)xMove, monster.Location.Y);
                    }

                    if (!isIntersectOnY)
                    {
                        monster.Location = new Point(monster.Location.X, monster.Location.Y + (int)yMove);
                    }
                }
            }
        }

        public static bool IsIntersectOnX(Monster monster, Monster monster2, double poschital)
        {
            return Math.Abs(monster.Location.X + poschital - monster2.Location.X) <= monster2.Width;
        }

        public static bool IsIntersectOnY(Monster monster, Monster monster2, double poschital)
        {
            return Math.Abs(monster.Location.Y + poschital - monster2.Location.Y) <= monster2.Height;
        }
    }
}
