VAR intro = true
VAR delivered_drugs = false
VAR received_drugs = false
VAR do_city_intro = true
VAR do_park_intro = true
VAR do_lake_intro = true
VAR do_office_intro = true
VAR kenzo_knows_about_tony = false

EXTERNAL show_item(name)
EXTERNAL hide_item(name)
EXTERNAL show_char(name)
EXTERNAL hide_char(name)
EXTERNAL set_line_type(type)
EXTERNAL load_start()

~ intro = true
~ delivered_drugs = false
~ received_drugs = false
~ do_city_intro = true
~ do_park_intro = true
~ do_lake_intro = true
~ do_office_intro = true
~ kenzo_knows_about_tony = false

-> lake_intro

//
// LAKE     LAKE    LAKE    LAKE
//
=== lake_intro ===
~ set_line_type("story")
{
- do_lake_intro:
~ show_item("portrait")
ée
Oh Frank, you really messed up this time
You just had to leave for a moment, yet you never came back
I still have the name of the bar where we were supposed to meet
~ show_item("napkin")
~ show_item("lake")
Maybe next time
}
~ do_lake_intro = false
~ intro = false
~ set_line_type("story")
-> lake_start

=== lake_start ===
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
 + [loc_office] -> tony_intro
 
 







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
~ intro = false

-> kenzo_start

=== kenzo_start ===
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
 + [vladjob]
    {
    - kenzo_knows_about_tony:
    The job with Tony
    They'll fuck you over first chance they get
    It's not worth it 
    - else:
    Did he say what kind of job?
    I can't imagine he has a dog for you to walk...
    You need to tell me if he's trying to steal our business
    I wonder if he got Frank already...
    }
    -> kenzo_start
 + [tonynote]
    ~ kenzo_knows_about_tony = true
    Tony?
    You got this from Vlad?
    Fucking turncoat piece of shit!
    ...
    -> kenzo_start
 + [vladtookmoney]
    Why would you give him your money?
    He'll never give it back, trust me
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
 + [harukiya]
    You can always find me here
    -> kenzo_start
    
 // LOCATIONS
 + [loc_park] -> vlad_intro
 + [loc_lake] -> lake_intro
 + [loc_office] -> tony_intro










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
 + [harukiya]
    That's the club where Kenzo hangs out
    Not really my style
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
 + [frankdebt]
    He owed me at least a grand
    We're even now though
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
 + [lake]
    It's pretty close to here 
    -> vlad_start
 + [drugsdelivered]
    Yeah, you did..
    Do you want a fucking medal or something?
    -> vlad_start
 + [vladjob]
    Ok, here's the address
    ~ show_item("tonynote")
    I'll call and let them know you're coming
    Go there now
    Don't tell anyone about it
    -> vlad_start

 // LOCATIONS
 + [loc_city] -> kenzo_intro
 + [loc_lake] -> lake_intro
 + [loc_office] -> tony_intro
 








//
// TONY     TONY    TONY    TONY
//
=== tony_intro ===
{
- do_office_intro:
~ intro = true
~ set_line_type("story")
You get to the address Vlad wrote for you
Immediately you're approached by a man 
He seems to have been anticipating you
He escorts you into a nearby building 
and before you know it, you're stuffed into a small smoke-filled room
}

~ do_office_intro = false
~ set_line_type("speech")
~ show_char("tony")
~ intro = false
Heya kid
Vlad tells me you're a distributor for Kenzo
So why don't you tell me about your career ambitions?
-> tony_start

=== tony_start ===
 + [unknown]
    Not sure I get your point, kid
    -> tony_start
 + [taketonyjob]
    You made the right choice, kid!
    -> go_to_start
 + [refusetonyjob]
    -> refuse_job
 + [vladjob]
    So you're interested! 
    You're mainly gonna be delivering like you're already doing
    But much more often and higher quantaties too
    Are you up for it?
    ~ show_item("taketonyjob")
    ~ show_item("refusetonyjob")
    ~ show_item("whyhireme")
    -> tony_start
 + [whyhireme]
    Okay, I'll level with you, kid
    Your friend Kenzo and his possé?
    Amateurs
    We're simply absorbing their workforce and taking over their responsibilities
    But if they don't submit, things could get ugly
    ~ show_item("tonythreat")
    -> tony_start
 + [frank] 
    Oh yes, tragic
    He was a troubled kid
    ~ show_item("franktroubled")
    -> tony_start
 + [franktroubled]
    Oh yes
    We just found him in the lake
    He must've taken his own life
    That or Kenzo got tired of waiting for his money
    ~ show_item("franksuicide")
    -> tony_start
 + [franksuicide]
    That or Kenzo
    Not something you wanna get mixed up in
    Best to stick with us
    We take care of our own 
    ~ show_item("whyhireme")
    -> tony_start
 + [drugs]
    So you have experience hauling drugs
    That's what we need
    ~ show_item("whyhireme")
    -> tony_start
 + [harukiya]
    I know that bar, kid
    You don't wanna hang out with those people
    Take a job with me instead
    I'll make sure you're taken care off
    ~ show_item("whyhireme")
    -> tony_start
 + [money]
    You can keep that one, kid
    And I'll make sure you get plenty more if you work for me
    ~ show_item("whyhireme")
    -> tony_start
 + [kenzoopinion]
    Kenzo is very unprofessional
    No doubt you've noticed
    ~ show_item("whyhireme")
    -> tony_start
 + [kenzojob]
    Trust me you don't want to work with him
    It never ends well
    Just look what happened to our dear Frank
    You don't want to end up like that
    ~ show_item("tonythreat")
    -> tony_start
 + [cold]
    We don't have to do small talk about the weather
    -> tony_start
 + [lake]
    The lake is awful cold and awful deep
    ~ show_item("tonythreat")
    -> tony_start
 + [park]
    That's Vlad's spot
    We can get you a spot, if you'd like
    ~ show_item("whyhireme")
    -> tony_start
 + [drugsdelivered]
    Vlad told me
    We have our own deliveries, that need to be made
    Maybe you're interested in some extra work?
    ~ show_item("whyhireme")
    -> tony_start
 + [vladtookmoney]
    He's a stickler isn't he
    Here. I'll reimburse you as a sign of good faith
    ~ show_item("money")
    -> tony_start
 + [frankdebt]
    It's true. He was in over his head.
    I would've forgiven him, but I guess he couldn't forgive himself
    -> tony_start
 + [tonynote]
    That's my info
    Hold on to that
    -> tony_start
 + [tonythreat]
    I would never!
    But I highly encourage you to take my offer
    -> tony_start
    

// tonythreat
// whyhireme
// taketonyjob
// refusetonyjob

//We'd like to see that operation cease


=== refuse_job ===
You're making a mistake kid
Who do you think killed your friend, huh?
~ hide_item("all")
~ show_item("kenzo")
~ show_item("tony")
~ show_item("frank")
~ show_item("vlad")
~ show_item("taketonyjob")
~ show_item("refusetonyjob")
* [kenzo]
    Hah, he barely noticed half his crew missing
    Last chance
    -> last_chance
* [vlad]
    Why? Because Kenzo called him a freak? 
    Maybe you should stop being so judgmental
    yeah
    I think you two should spend more time together
    ~ hide_char("tony")
    ~ show_char("vlad")
    Let's take a walk
    -> go_to_start
* [tony]
    Me?!
    Vlad, why don't you tell him how we feel about ungratefulness?
    ~ hide_char("tony")
    ~ show_char("vlad")
    Let's take a walk
    -> go_to_start
* [frank]
    Yeah, he committed suicide 
    Just like you
    ~ hide_char("tony")
    ~ show_char("vlad")
    Let's take a walk
    -> go_to_start
    
=== last_chance === 
+ [taketonyjob]
    You made the right choice, kid!
    -> go_to_start
+ [refusetonyjob]
    What a shame...
    ~ hide_char("tony")
    ~ show_char("vlad")
    Let's go talk to Frank
    -> go_to_start
    
=== go_to_start ===
~ load_start()
-> END










