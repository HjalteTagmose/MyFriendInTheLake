VAR intro = true
VAR delivered_drugs = false
VAR received_drugs = false
EXTERNAL show_item(name)
EXTERNAL hide_item(name)

-> lake_intro

//
// LAKE     LAKE    LAKE    LAKE
//
=== lake_intro ===
~ intro = true
Franky
~ show_item("portrait")
-> lake_start

=== lake_start ===
~ intro = false
 + [unknown] -> lake_unknown
 + [drugs] -> lake_drugs
 + [cold] -> lake_cold
 + [frank] -> lake_frank
 // LOCATIONS
 + [city] -> kenzo_intro
 + [park] -> vlad_intro

=== lake_cold ===
Are you cold too, Frank?
-> lake_start

=== lake_drugs ===
You were supposed to deliver this
so you owe me one
...
-> lake_start

=== lake_unknown ===
I don't know what this has to do with anything
-> lake_start

=== lake_frank ===
That's him now
Floating there as if he wasn't walking yesterday
...
-> lake_start











//
// VLAD     VLAD    VLAD    VLAD
//
=== vlad_intro ===
~ intro = true
Hey man, what you need?
-> vlad_start

=== vlad_start ===
~ intro = false
 + [unknown] -> vlad_unknown
 + [drugs] -> vlad_drugs -> vlad_start
 + [cold] -> vlad_cold -> vlad_start
 + [frank] -> vlad_frank -> vlad_start
 // LOCATIONS
 + [city] -> kenzo_intro
 + [lake] -> lake_intro
 
=== vlad_cold ===
I got stuff, that'll make you feel like you're on the beach.
 -> vlad_start
 
=== vlad_drugs ===
~delivered_drugs = true
You're the new delivery boy then?
I guess Frank couldn't hack it  
 -> vlad_start
 
=== vlad_unknown ===
What are you talking about?
 -> vlad_start
 
=== vlad_frank ===
{
- delivered_drugs:
He delivered to me before you
I guess he got out of the game 
Always seemed like a softy to me anyway
- else:
I don't know who that is
}
-> vlad_start











//
// KENZO    KENZO   KENZO   KENZO 
//
=== kenzo_intro ===
~ intro = true
Don't I know you?
-> kenzo_start

=== kenzo_start ===
~ intro = false
 + [unknown] -> kenzo_unknown
 + [drugs] -> kenzo_drugs
 + [cold] -> kenzo_cold
 + [frank] -> kenzo_frank
 // LOCATIONS
 + [park] -> vlad_intro
 + [lake] -> lake_intro

=== kenzo_cold ===
-> kenzo_start

=== kenzo_drugs ===
-> kenzo_start

=== kenzo_unknown ===
Huh?
-> kenzo_start

=== kenzo_frank ===
-> kenzo_start





















