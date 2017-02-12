using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventController : MonoBehaviour {

    public List<RandomEventScript> randomEvents = new List<RandomEventScript>();

    void Start()
    {
        BuildEventList();
    }


    //creation of random events and storing them for later use
	public void BuildEventList()
    {
        randomEvents.Add(new RandomEventScript("Blown tire!", 
                                                "This old van has it's issues. One of your tires blows out leaving you stranded for a while. If Jeff is with the group he can help you out!", 
                                                "Fix it yourself! (-Happiness)", "Call a towing company to help you out (-$150)", "", 
                                                -1, -150, 0, "Jeff", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Stop for Gas", 
                                                "The van runs low on gas occasionally, its time to stop for fuel. There is a gas station with a convenience store here.", 
                                                "", "Complete fillup (-$75)", "", 
                                                0, -75, 0, "None", null, true, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Lost for hours....",
                                                "You try to take a shortcut and end up lost for several hours. The crew has heard that you should eat all of your food right away to make sure the calories go to good use in an emergency. If Dan is with the party he can make a run for the border and find some tacos for the group!",
                                                "", "Purchase survival rations at the next stop. (-$215)", "(-8 Food).",
                                                0, -215, -8, "Dan", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Johnny V in an RV",
                                                "You come across Johnny V in a rockin' RV at a shady rest stop. Traveling the countryside, Johnny is an unstoppable force of kindness and lewd mishaps with texting programs. You decide to hang out with him for a while. In addition to the below rewards, the whole crew gains extra happiness, Johnny V has an infectious personality! Maybe you can catch him on his sweet boat?",
                                                "Have a rad 'party' with Johnny V. (++Happiness)", "Livestream direct from Johnny's RV. (+$900)", "Johnny has some questionable shit in his fridge you can take. (+20 Food)",
                                                2, 900, 20, "None", null, false, RandomEventScript.RewardTypes.Happiness, 2, 5));
        randomEvents.Add(new RandomEventScript("Left the Van Unlocked",
                                                "You accidentally leave the van unlocked. Someone has broken in and stolen all your clothes! Dan doesnt mind, and goes shirtless for the next few days acting like Triple H. If Vinny is with the party he keeps a stash of black V-necks for just such an occasion!",
                                                "Go shirtless for a few days (-Happiness)", "Buy a new wardrobe (-$750)", "",
                                                -2, -750, 0, "Vinny", "Dan", false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Meat Dimension?",
                                                "You stop at a roadside diner that advertises a quintuple beef bowl, and its free if you finish it within 30 minutes! This is sure to be a great idea!",
                                                "Enter the meat dimension (+Happiness)", "", "",
                                                3, 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Truckstop Bathroom Finds!",
                                                "While exploring every corner of the truckstop bathroom you find that the soap dispenser is packed with cash! Sweet!",
                                                "", "Windjammers money-match time! (+$1000)", "",
                                                0, 1000, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Pre-Ban Goodness",
                                                "You find a case of pre-ban Four-loko at a flea market. The guys drink the entire case and have a good time tonight!",
                                                "Drink Up! (+Happiness)", "", "",
                                                2, 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Over Heated!",
                                                "The van sputters to a stop at the side of the road. You spend the next few hours trying to get it going again.",
                                                "Break out the wrenches (-Happiness)", "Call Roadside assistance (-$900)", "",
                                                Random.Range(-3, -1), -900, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Road Hypnosis",
                                                "Hours and hours, miles and miles pass under Van. How long have you been driving? Did you fall asleep for a second?",
                                                "So far to go.. (-Happiness)", "", "",
                                                -2, 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Are we there yet?",
                                                "The guys are getting impatient. Everyone is getting restless. Except Drew if he is with the group, who is incredibly patient, waiting for the perfect moment....",
                                                "Well, are we? (-Happiness)", "", "",
                                                Random.Range(-3, -1), 0, 0, "None", "Drew", false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Radio Broken",
                                                "Is there anything worse than a road trip with no radio?",
                                                "This really sucks. (-Happiness)", "", "",
                                                Random.Range(-3, -1), 0, 0, "Alex", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Tangled!",
                                                "After live streaming all night it takes you hours to get everything put away again.",
                                                "Does someone have a cable tie? (-Happiness)", "", "",
                                                Random.Range(-2, -1), 0, 0, "Jason", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("No Water!",
                                                "Last night's hotel had no running water when you woke up this morning. An unfortunate side effect is that none of the crew could shower last night... this is going to be a long day.",
                                                "Anyone have some air freshener? (-Happiness)", "", "",
                                                Random.Range(-2, -1), 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("The Lang Zone",
                                                "Dave Lang is an unstoppable force! He catches up to your van in his totally bad-ass 1987 Trans Am and invites you to Get Bopped.",
                                                "", "Dave is the ultimate street racer  (-$500)", "",
                                                0, -500, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("You Shall Not Pass!",
                                                "The bridge is out, it takes you several hours to go around and no one is happy about it.",
                                                "This is taking forever (-Happiness)", "", "",
                                                Random.Range(-2, -1), 0, 0, "Vinny", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Have you heard the good news?",
                                                "You catch Adam Boyes at a roadside diner. He tells you all about *REDACTED* the exciting new game from *REDACTED*.",
                                                "WOW *REDACTED* sounds amazing!(+Happiness)", "", "",
                                                Random.Range(1, 2), 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Is it a Bird? Is it a Plane?",
                                                "No, its just John Drake with a wheelbarrow full of diet soda. You are treated to a passionate speech on all the ways Dan is a literal monster, and stop to buy him some more soda.",
                                                "", "OK John, here's your diet soda (-$250)", "",
                                                0, -250, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Is this a passing zone?",
                                                "A big rig pulls out in the left lane to pass another big rig. A few hours later he completes the pass.",
                                                "Why Us (-Happiness)", "", "",
                                                -2, 0, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Questionable Roadside Food Stand",
                                               "You buy some tamales from a guy with an easy-up anda cooler int he back of a Monte Carlo. The only authentic tamale experience.",
                                               "No thanks! (-Happiness)", "Awesome! I'll take 10!(-$100, +food)", "",
                                               -2, -100, 0, "None", null, false, RandomEventScript.RewardTypes.Food, 5, 2));
        randomEvents.Add(new RandomEventScript("Wanna ride the roller coaster?",
                                               "Its only a dollar...",
                                               "I dont like roller coasters. (-Happiness)", "Um... ok..... (-$1)", "",
                                               -2, -1, 0, "None", "Jeff", false, RandomEventScript.RewardTypes.Happiness, 1, 1));
        randomEvents.Add(new RandomEventScript("Puppy stampede triggered by chomps",
                                               "You are being attacked by a herd of puppies! There's at least one staff member who could help with this.",
                                               "Puppies Imminent! (+Happiness)", "", "",
                                               2, 0, 0, "Rorie", null, false, RandomEventScript.RewardTypes.Happiness, 1, 1));
        randomEvents.Add(new RandomEventScript("Impromptu Roadside Stream!",
                                               "You decide to livestream from the roadside, playing a slew of indie games. Brad can certainly help with this!",
                                               "", "What about our data plan.. (-$250)", "",
                                               0, -250, 0, "Brad", null, false, RandomEventScript.RewardTypes.Happiness, 1, 1));
        randomEvents.Add(new RandomEventScript("Yo Dawg",
                                               "I heard you like game jam games about road trips so I made this game jam game about a road trip while making the game jam game ON a road trip",
                                               "This is stressful to even read (-Happiness)", "", "",
                                               -2, 0, 0, "Vinny", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Klepek Cameo",
                                               "Patrick Klepek sees you livestreaming from a dirty Motel 6. He walks across the hall to your room to make a special appearance!",
                                               "", "Get That View Money (+$43)", "",
                                               0, 43, 0, "None", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Dan's Trivia Hour",
                                               "Dan wants to money match on some MGS trivia. Drew can help out if he's around!",
                                               "", "Lets do this! ($???)", "",
                                               0, Random.Range(-500, 1500), 0, "Drew", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("From Russia With Love",
                                               "Lots of talk about russian spies trying to hack into GBEAST Headquarters! Drew can steer the conversation another direction if he's around...",
                                               "Dan's emails though... (-Happiness)", "", "",
                                               Random.Range(-4, -1), 0, 0, "Drew", null, false, RandomEventScript.RewardTypes.None, 0, 0));
        randomEvents.Add(new RandomEventScript("Cant Find Tacos",
                                               "The crew really wants Tacos, and no one knows where any are..  Unless Dan is here!",
                                               "", "", "I guess I'll just eat this.. (-food)",
                                               0, 0, Random.Range(-5, -1), "Dan", null, false, RandomEventScript.RewardTypes.None, 0, 0));


    }
}
 