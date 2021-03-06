using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public sealed class EnemyImages
    {
        List<string> Demon;
        List<string> Vampire;
        List<string> Imp;
        List<string> CryptLord;

        private static readonly Lazy<EnemyImages> instance =
            new Lazy<EnemyImages>(() => new EnemyImages());

        private EnemyImages()
        {
            Demon = new List<string>()
            {
                @"                              ,-.                             ",
                @"         ___,---.__          /'|`\          __,---,___        ",
                @"     ,-'    \`    `-.____,-'  |  `-.____,-'    //    `-.      ",
                @"   ,'        |           ~'\     /`~           |        `.    ",
                @"  /      ___//              `. ,'          ,  , \___      \   ",
                @" |    ,-'   `-.__   _         |        ,    __,-'   `-.    |  ",
                @" |   /          /\_  `   .    |    ,      _/\          \   |  ",
                @" \  |           \ \`-.___ \   |   / ___,-'/ /           |  /  ",
                @"  \  \           | `._   `\\  |  //'   _,' |           /  /   ",
                @"   `-.\         /'  _ `---'' , . ``---' _  `\         /,-'    ",
                @"      ``       /     \    ,='/ \`=.    /     \       ''       ",
                @"              |__   /|\_,--.,-.--,--._/|\   __|               ",
                @"              /  `./  \\`\ |  |  | /,//' \,'  \               ",
                @"             /   /     ||--+--|--+-/-|     \   \              ",
                @"            |   |     /'\_\_\ | /_/_/`\     |   |             ",
                @"             \   \__, \_     `~'     _/ .__/   /              ",
                @"              `-._,-'   `-._______,-'   `-._,-'               "
            };

            Vampire = new List<string>()
            {
                @"                __.......__                ",
                @"             .-:::::::::::::-.             ",
                @"           .:::''':::::::''':::.           ",
                @"         .:::'     `:::'     `:::.         ",
                @"    .'\  ::'   ^^^  `:'  ^^^   '::  /`.    ",
                @"   :   \ ::   _.__       __._   :: /   ;   ",
                @"  :     \`: .' ___\     /___ `. :'/     ;  ",
                @" :       /\   (_|_)\   /(_|_)   /\       ; ",
                @" :      / .\   __.' ) ( `.__   /. \      ; ",
                @" :      \ (        {   }        ) /      ; ",
                @"  :      `-(     .  ^'^  .     )-'      ;  ",
                @"   `.       \  .'<`-._.-'>'.  /       .'   ",
                @"     `.      \    \;`.';/    /      .'     ",
                @"       `._    `-._       _.-'    _.'       ",
                @"        .'`-.__ .'`-._.-'`. __.-'`.        ",
                @"      .'       `.         .'       `.      ",
                @"    .'           `-.   .-'           `.    "
            };

            Imp = new List<string>()
            {
                @"                        *  ",
                @"                     *     ",
                @"          (\___/)     (    ",
                @"          \ (- -)     )\ * ",
                @"          c\   >'    ( #   ",
                @"            )-_/      '    ",
                @"     _______| |__    ,|//  ",
                @"    # ___ `  ~   )  ( /    ",
                @"    \,|  | . ' .) \ /#     ",
                @"   _( /  )   , / \ / |     ",
                @"    //  ;;,,;,;   \,/      ",
                @"     _,#;,;;,;,            ",
                @"    /,i; ; ;,,;#,;         ",
                @"   ((  %; ;,;,; ;,;        ",
                @"    ))  ;#;,;%;;,,         ",
                @"  _//    ;,;; ,#;,         ",
                @" / _)     #,;  //          ",
                @"        //    \|_          ",
                @"        \| _ |#\           ",
                @"         |#\    -'         "
            };

            CryptLord = new List<string>()
            {
            @"       -. -. `.  / .-' _.'  _      ",
            @"      .--`. `. `| / __.-- _' `     ",
            @"     '.-.  \  \ |  /   _.' `_      ",
            @"     .-. \  `  || |  .' _.-' `.    ",
            @"   .' _ \ '  -    -'  - ` _.-.     ",
            @"    .' `. %%%%%   | %%%%% _.-.`-   ",
            @"  .' .-. ><(@)> ) ( <(@)>< .-.`.   ",
            @"    (('`(   -   | |   -   )''))    ",
            @"   / \\#)\    (.(_).)    /(#//\    ",
            @"  ' / ) ((  /   | |   \  )) (`.`.  ",
            @"  .'  (.) \ .md88o88bm. / (.) \)   ",
            @"    / /| / \ `Y88888Y' / \ | \ \   ",
            @"  .' / O  / `.   -   .' \  O \ \\  ",
            @"   / /(O)/ /| `.___.' | \\(O) \    ",
            @"    / / / / |  |   |  |\  \  \ \   ",
            @"    / / // /|  |   |  |  \  \ \    ",
            @"  _.--/--/'( ) ) ( ) ) )`\-\-\-._  ",
            @" ( ( ( ) ( ) ) ( ) ) ( ) ) ) ( ) ) "
            };
        }

        public static EnemyImages Instance
        {
            get
            {
                return instance.Value;
            }
        }

        public List<string> GetDemon() { return Demon; }
        public List<string> GetVampire() { return Vampire; }
        public List<string> GetImp() { return Imp; }
        public List<string> GetCryptLord() { return CryptLord; }

    }
}
