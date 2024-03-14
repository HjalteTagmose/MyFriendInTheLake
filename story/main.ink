VAR intro = true
VAR delivered_drugs = false
VAR received_drugs = false
VAR do_city_intro = true
VAR do_park_intro = true
VAR do_lake_intro = true

EXTERNAL show_item(name)
EXTERNAL hide_item(name)
EXTERNAL show_char(name)
EXTERNAL hide_char(name)
EXTERNAL set_line_type(type)

-> lake_intro

//
// LAKE     LAKE    LAKE    LAKE
//
=== lake_intro ===
~ set_line_type("story")
{
- do_lake_intro:
~ show_item("portrait")
Oh Frank, you really messed up this time
You just had to leave for a moment, yet you never came back
I still have the name of the bar where we were supposed to meet
~ show_item("napkin")
~ show_item("lake")
Maybe next time
}
~ do_lake_intro = false
-> lake_start

=== lake_start ===
~ intro = false
~ do_lake_intro = false
~ set_line_type("story")
 + [unknown] 
    I don't know what this has to do with anything
    -> lake_start
 + [drugs] 
    You were supposed to deliver this
    So you owe me one..
    -> lake_start
 + [frank]
    That's him now
    Floating there as if he wasn't walking yesterday
    -> lake_start
 + [cold]
    Are you cold too, Frank?
    ...
    -> lake_start
 + [harukiya]
    I was there, Frank, but you never came..
    -> lake_start
 + [money]
    I might be taking over your job
    -> lake_start
 + [lake]
    How's the water?
    -> lake_start
 + [vladjob]
    Should I take a job with Vlad?
    Will that help me find out what happened?
    Am I just a drugdealer at this point?
    -> lake_start
 + [vladtookmoney]
    Can you believe Vlad took my money?
    Maybe Kenzo was right about him
    -> lake_start
 + [kenzojob]
    Seems I'm filling in for you today
    -> lake_start
 + [drugsdelivered]
    I delivered drugs for the first time tonight
    Still feels weird, that you used to do this
    -> lake_start
 + [kenzoopinion]
    I wonder if you would've agreed with him
    -> lake_start
 + [park]
    The park is spooky at night, don't ya think?
    -> lake_start

 // LOCATIONS
 + [loc_city] -> kenzo_intro
 + [loc_park] -> vlad_intro
 
 







//
// KENZO    KENZO   KENZO   KENZO 
//
=== kenzo_intro ===
{
- do_city_intro:
~ intro = true
~ set_line_type("story")
Neverending housing blocks steal your view of the sky
The streets are desolate, but you hear muffled noises from the entrance
A bonechilling cold hits you 
~ show_item("cold")
It's honestly a miracle, you found this place
As you walk up to the entrance, a guy spots you and comes over
~ set_line_type("speech")
~ show_char("kenzo")
Don't I know you?
}

~ do_city_intro = false
~ set_line_type("speech")
~ show_char("kenzo")

-> kenzo_start

=== kenzo_start ===
~ intro = false
~ set_line_type("speech")
 + [unknown]
    Huh?
    -> kenzo_start
 + [drugs]
    Are you bailing on me? 
    Just go to the park and find Vlad
    -> kenzo_start
 + [cold]
    It sure is
    -> kenzo_start
 + [frank]
    Oh yeah, you're Frank's friend
    He hasn't shown up today
    You tell him, he better show up and start paying off his debts
    ~ show_item("frankdebt")
    The boss is pissed
    -> kenzo_start
 + [frankdebt] 
    Yea, that dude is flakey as shit
    I always gotta cover for him, but hey, he gets the job done
    Or he used to... 
    Do you maybe wanna help him not get his arms broken
    and do something for me? 
    ~ show_item("kenzojob")
    -> kenzo_start
 + [kenzojob]
    I need you to deliver this
    ~ show_item("drugs")
    There's a guy in the park waiting for it right now
    ~ show_item("park")
    Just look for a creepy dude with a suit
    Fucker freaks me out, not gonna lie
    ~ show_item("kenzoopinion")
    -> kenzo_start
 + [kenzoopinion]
    If you knew him like I do, you'd agree
    -> kenzo_start
 + [lake]
    I know of it?
    -> kenzo_start
 + [park]
    {
    - delivered_drugs:
    What about it?
    - else:
    Yea, that's where Vlad is
    So you better get going
    }
    -> kenzo_start
 + [drugsdelivered]
    Good job
    Thanks for filling in
    Here's your cut
    ~ show_item("money")
    -> kenzo_start
 + [money]
    What? Not enough for you?
    Too bad!
    -> kenzo_start
 // LOCATIONS
 + [loc_park] -> vlad_intro
 + [loc_lake] -> lake_intro









//
// VLAD     VLAD    VLAD    VLAD
//
=== vlad_intro ===
{
- do_park_intro:
~ intro = true
~ set_line_type("story")
It's almost completely dark at this point
The rustling of leaves and apparent desolation leaves you with an eerie feeling
...
Then, as if out of nowhere, a figure appears
}

~ do_park_intro = false
~ set_line_type("speech")
~ show_char("vlad")
~ intro = false
Hey man, what you need?
-> vlad_start

=== vlad_start ===
 + [unknown]
    What are you talking about?
     -> vlad_start
 + [drugs]
    ~ hide_item("drugs")
    ~ delivered_drugs = true
    You're the new delivery boy then?
    I guess Frank couldn't hack it
    ~ show_item("drugsdelivered")
    -> vlad_start
 + [cold]
    I got stuff, that'll make you feel like you're on the beach
    -> vlad_start
 + [frank]
    {
    - delivered_drugs:
    He delivered to me before you
    I guess he got out of the game
    Always seemed like a softy to me anyway
    - else:
    I don't know who that is
    }
    -> vlad_start
 + [money]
    That's what Kenzo paid you? Hah!
    Tell me if you need a real job, I know a guy
    ~ show_item("vladjob")
    ~ set_line_type("story")
    Vlad quietly pockets the money
    ~ set_line_type("speech")
    ~ show_item("vladtookmoney")
    ~ hide_item("money")
    -> vlad_start
 + [vladtookmoney]
    That's for making me wait 
    -> vlad_start
 + [kenzojob]
    I figured he did 
    Bet he pays shit too
    Tell me if you need more work, I know a guy
    ~ show_item("vladjob")
    -> vlad_start
 + [kenzoopinion]
    He can think what he wants
    He won't be around much longer 
    -> vlad_start

 // LOCATIONS
 + [loc_city] -> kenzo_intro
 + [loc_lake] -> lake_intro
 

















