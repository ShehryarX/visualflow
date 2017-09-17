# VisualFlow

by Shehryar Assad, Moshe Rienhart, Tejas Shah & Sarvesh Kumar

What it does
VisualFlow primarily reads in a large form of data and begins to index it locally. It also processes the data in a clustering-algorithm to identify similar points and place them together visually. The app also increases the size proportional to the number of points that are similar. For the artificial intelligence portion, a regression is run to allow users to ask about factors, how factors come to be, filter data and even graph accurate data during a particular time interval. The graphs generated are very interactive, as the whole application, and they use a LeapMotion to perform different commands. The LeapMotion allows users to do more by doing less. Also, the audio is taken in and filtered real time to identify commands and their respective parameters. We used Vitech's insurance data to create detailed statistics and a competent artificial intelligence system to identify trends and patterns by itself. This is extremely useful for heavy-statistical use. It truly allows you to view, edit, and ask questions about anything you see. For example, you can ask it to filter out all the ages from 1 to 19 years old, ask it why there's a trend in a specific category in a specific city, or to graph a correlation such as the success of each monthly campaign concerning time and users. Lastly, VisualFlow uses virtual reality to allow users to get an authentic touch of the data; shifting the data by waving their hand, tapping to zoom, or getting more options by just turning your hand.

Abstract
Since this app uses Vitech's insurance data, we leverage this large database to train the artificial intelligence of the application. We made this application as if we were the managers of Vitech, and as if we wanted to make sense of statistics, and how and why a trend occurs. We ensured that the presentation of the data was as precise and specific as the end-user needs.

How we built it
We used a variety of statistical algorithms, all of which have runtime less than O(n log n) and have been optimized to traverse through our code much faster. Since there is a lot of data involved, we chose to use the Rethink database through Node.js to optimize our code for efficiency and simplicity. Not to mention, there as a lot of multi-threading used to lower the total cost upon the CPU. We used Unity and various plugins to generate graphs. For the artificial intelligence section, we used Api.AI along with a custom-made API receiver to allow for the sending and receiving of commands. The virtual reality aspect was built with LeapMotion, an Oculus-similar hardware, and of course, Unity.

Challenges we ran into
Too much food Too many chairs Too less sleep Writing up this post

Accomplishments that we're proud of
Splitting the application into two principal components and combining them together in a very efficient manner. Our team had split up to divide and conquer to solve this problem and through good coding practices, we managed to do it.

What we learned
We learned about the importance of the presence of project management; setting deadlines and people to perform various tasks.

What's next for VizTech
VizTech will continue to expand and hopefully will be used by companies with a large set of data that needs to be personally analyzed. Trends that the computer can't see, you now can.
