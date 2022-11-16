<!-- Ready-Lamp off;PenUp;PenAbsolute;QUality=norm;LaserFrequency=10000hz;
    AccelerationSelect 5m/ss;toolWaitingstime all 0;External Gas on;PowerBox2(Vacuumpump) on;PowerBox4(Vacuun cleaner) on;Delay {3s}; -->
<!-- be careful with the first command, this will also used for identifying the plt files -->
<property id="prejob" text="XX13,12,0;PU;PA;QU2;LF10000;AS{downacceleration};PW0,0,0,0;EG1;PB2,1;PB4,1;SD{delay};"/>

<!-- Job No 0(EndOfJob Signal to the Plugin);PenUp toplleft corner;ExternalGas off;Wait 3sec;PowerBox2 (Vacuumpump) off;
    PowerBox4 (Vacuum cleaner) off;Message how finnished the job;Ready-Lamp on;offline -->
<property id="postjob" text="JB0;PU100000,100000;EG0;SD300;PB2,0;PB4,0;XX12,2;MSDone by {username};XX13,12,1;NR;"/>


<!-- HPGL pretool command -->
<!-- VelocityS down;Laserpower;MinimalLaserpower;recess Power-->
<property id="pretool" text="XX12,2;MSTool:{id};VS{speeddown},{speedup};LL{powerwork};ML{powermin};EL{powerrecess};" ishidden="true" />

<!-- PenUp; -->
<property id="posttool" text="PU;"  ishidden="true" />


XX13,12,0;PU;PA;QU2;LF10000;AS2;PW0,0,0,0;EG1;PB2,1;PB4,1;SD;
MSBox 1;VS{speeddown},{speedup};LL{powerwork};ML{powermin};EL{powerrecess};

MSBox 2;VS{speeddown},{speedup};LL{powerwork};ML{powermin};EL{powerrecess};

MSBox 2;VS{speeddown},{speedup};LL{powerwork};ML{powermin};EL{powerrecess};