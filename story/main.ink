VAR intro = true
VAR delivered_drugs = false
VAR received_drugs = false

EXTERNAL show_item(name)
EXTERNAL hide_item(name)
EXTERNAL show_char(name)
EXTERNAL hide_char(name)

-> lake_intro

//
// LAKE     LAKE    LAKE    LAKE
//
=== lake_intro ===
~ show_item("portrait")
Oh Frank, you really messed up this time
You just had to leave for a moment, yet you never came back
I still have the name of the bar where we were supposed to meet
~ show_item("napkin")
Maybe next time

-> lake_start

=== lake_start ===
~ intro = false
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

 // LOCATIONS
 + [loc_city] -> kenzo_intro
 + [loc_park] -> vlad_intro
 
 







//
// KENZO    KENZO   KENZO   KENZO 
//
=== kenzo_intro ===
~ intro = true
Neverending housing blocks steal your view of the sky
A small sign labeled B1 marks your location
The streets are desolate, but you hear muffled noises from the entrance
A bonechilling cold hits you 
~ show_item("cold")
It's honestly a miracle, you found this place
As you walk up to the entrance, a guy spots you and comes over
~ show_char("kenzo")
Don't I know you?
-> kenzo_start

=== kenzo_start ===
~ intro = false
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
 // LOCATIONS
 + [loc_park] -> vlad_intro
 + [loc_lake] -> lake_intro









//
// VLAD     VLAD    VLAD    VLAD
//
=== vlad_intro ===
~ intro = true
It's almost completely dark at this point
The rustling of leaves and apparent desolation leaves you with an eerie feeling
...
Then, as if out of nowhere, a figure appears
~show_char("vlad")
Hey man, what you need?
-> vlad_start

=== vlad_start ===
~ intro = false
 + [unknown]
    What are you talking about?
     -> vlad_start
 + [drugs]
    ~delivered_drugs = true
    You're the new delivery boy then?
    I guess Frank couldn't hack it
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

 // LOCATIONS
 + [loc_city] -> kenzo_intro
 + [loc_lake] -> lake_intro
 

















