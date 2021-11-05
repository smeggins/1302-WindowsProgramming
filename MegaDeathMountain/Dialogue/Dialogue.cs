using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomSlayer9000OmegaForce1
{

    public sealed class Dialogue
    {
        List<string> attackMsg;
        List<string> defendMsg;
        List<string> missMsg;
        List<string> hitMsg;
        List<string> killMsg;
        Random RNG = new Random();
        private static readonly Lazy<Dialogue> instance =
            new Lazy<Dialogue>(() => new Dialogue());

        private Dialogue()
        {
            attackMsg = new List<string>()
            {
                " takes a mighty swing.",
                " rolls to the left and stabs",
                " jumps from a rock, attacking from above",
                " feigns a block and attacks."
            };
            defendMsg = new List<string>()
            {
                " prepares to deflect the incoming blow",
                " jumps back a step",
                " rolls to the side trying to avoid the attack",
                " prepares to spring away from the attack",
                " attempts to absorb the blow on their armor"
            };
            missMsg = new List<string>()
            {
                " ducks as the attack flies inches from their head",
                " was inches away from having its head taken off",
                " sucessfully dodges the attack",
                " manages to block the powerful attack",
                " laughs at your feeble attempts at attacking it"
            };
            hitMsg = new List<string>()
            {
                " flies back from the powerful attack",
                " takes a deep gash in their side",
                " is knocked down from the attack",
                " receives a mighty blow",
                " staggers backwards from the attack"
            };
            killMsg = new List<string>()
            {
                " collapses from their injuries",
                " takes a final blow and falls to the ground lifeless",
                " falls to the ground dead",
                " takes one final blow and expires",
                " emits a final curse as they succumb to their wounds"
            };
        }

        public static Dialogue Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<string> getAttackMsg() { return attackMsg; }
        public List<string> getDefendMsg() { return defendMsg; }
        public List<string> getMissMsg() { return missMsg; }
        public List<string> getHitMsg() { return hitMsg; }
        public List<string> getKillMsg() { return killMsg; }

        public string getRandomAttackMsg() { return attackMsg[RNG.Next(0, attackMsg.Count)]; }
        public string getRandomDefendMsg() { return defendMsg[RNG.Next(0, defendMsg.Count)]; }
        public string getRandomMissMsg() { return missMsg[RNG.Next(0, missMsg.Count)]; }
        public string getRandomHitMsg() { return hitMsg[RNG.Next(0, hitMsg.Count)]; }
        public string getRandomKillMsg() { return killMsg[RNG.Next(0, killMsg.Count)]; }
    }
}
