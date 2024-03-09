VAR gained_trust = false

-> intro

=== intro ===
Hey man, what you need?
-> start

=== start ===
 + [unknown] -> unknown
 + [drugs] -> drugs
 + [cold] -> cold
 + [frank] -> frank
 
=== cold ===
I got stuff, that'll make you feel like you're on the beach.
-> start

=== drugs ===
~gained_trust = true
You're the new delivery boy then?
I guess Frank couldn't hack it  
-> start

=== unknown ===
What are you talking about?
-> start

=== frank ===
{
- gained_trust:
He delivered to me before you
I guess he got out of the game 
Always seemed like a softy to me anyway
- else:
I don't know who that is
}
-> start