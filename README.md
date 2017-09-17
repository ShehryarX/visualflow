# VisualFlow
## Inspiration
Lots of data is necessarily that useful in all its forms. Visual flow is a complex, yet elegant solution to making data easier to making trends and factors more apparent. It leverages and artificial intelligence network that allows users to query the application for potential factors using natural language processing. Overall, it makes asking questions about why the data looks that way it does, much, much more elegant.

## What it does
VisualFlow essentially reads in a large form of data and begins to index it locally. It also processes the data in a clustering-algorithm to identify similar points and place them together visually. The app also increases the size proportional to the number of points that are similar. For the artificial intelligence portion, a regression is ran to allow users to ask about factors, how factors come to be, filter data, and even graph specific data during a specific time interval. The graphs generated are very interactive, like the whole application, and they use a LeapMotion to perform different commands. The LeapMotion allows users to do more by doing less. In addition, the audio is taken in and filtered real time to identify commands and their respective parameters. We used Vitech's insurance data to create detailed statistics and a competent artificial intelligence system to identify trends and patterns by itself. This is extremely useful for heavy-statistical use. It truly allows you to view, edit, and ask questions about anything you see. For example, you can ask it to filter out all the ages from 1 to 19 years old, ask it why there's a trend in a specific category in a specific city, or to graph a correlation such as the success of each monthly campaign with respect to time and users. Lastly, VisualFlow uses virtual reality to allow users to get a true touch of the data; shifting the data by waving their hand, tapping to zoom, or getting more options by simply turning your hand.

## How we built it
We used a variety of statistical algorithms, all of which have runtime less than O(n log n) and have been optimized to traverse through our code much faster. Since there is a lot of data involved, we chose to use the Rethink database through Node.js to optimize our code for efficiency and simplicity. Not to mention, there as a lot of multi-threading used to lower the total cost upon the CPU. We used Unity and various plugins to generate graphs. For the artificial intelligence section, we used Api.AI along with a custom-made API receiver to allow for the sending and receiving of commands. The virtual reality aspect was built with LeapMotion, an Oculus-similar hardware, and of course, Unity.

## Challenges we ran into
Too much food
Too many chairs
Too less sleep
Writing up this post

## Accomplishments that we're proud of
Splitting the application into two main components and combing it in a very efficient manner.

## What we learned
We learned about the importance of the presence of project management; setting deadlines and people to perform various tasks.

## What's next for VizTech
VizTech will continue to expand and hopefully will be used by companies with a large set of data that needs to be personally analyzed. Trends that the computer can't see, you now can.
