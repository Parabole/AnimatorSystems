# AnimatorSystems
This repository contains DOTS helpers to get/set things on the Unity Animator. Think of it as a middleman between pure DOTS and the Animator. With this, you can read state info, request the setting of bools, int, float and trigger inside burst-compiled jobs. 

Note that this will become irrelevant once Unity launches its DOTS animation graph. Also note that we do not provide tutorials or any kind of official support for this package... We just use it internally for the making of our next game, and thought it could be a good contribution to making all of our lives easier :)

## Installation
* For development, simply clone the repo and use it like any other Unity project
* For deployment, you can add this line to your package manifest.json: "com.parabole.animator-systems": "githuburl.git#X.X.X" (change url for the github url and X.X.X with the version tag you wish to use, ex: 0.3.0)

### Updating the package
First update SemVer version in package.json (again following [mob-sakai process ](https://www.patreon.com/posts/25070968)), then:

Subtree split for UPM
1. git subtree split --prefix=Assets/AnimatorSystems --branch upm
1. git tag SEMVER_NUMBER_HERE upm
1. git push origin upm --tags

## Usage
Some examples: 
* To change parameters at runtime, add elements to the type buffer you wish to use
* To change animator override, add AnimatorOverridesContainer to the Animator Game Object, and then add SetAnimatorOverride with the index of the Animator Override you wish to use.
* To read AnimatorStateInfo, simply query CurrentStateInfo

And etc.

Enjoy !
