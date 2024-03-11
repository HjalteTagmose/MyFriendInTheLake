VAR delivered_drugs = false

=== vlad_intro ===
Hey man, what you need?
-> vlad_start

=== vlad_start ===
 + [unknown] -> vlad_unknown
 + [drugs] -> vlad_drugs
 + [cold] -> vlad_cold
 + [frank] -> vlad_frank
 
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