# AnimatorSystems
* This repository contains DOTS helpers to get/set things on the Unity Animator. 
* Note that this will become irrelevant once Unity launches its DOTS animation graph.
* Also note that we do not provide tutorials or any kind of official support for this package.
* We just use it internally for the making of our next game, and thought it could be a good contribution to making all of our lives easier.

## Installation
* For development, simply clone the repo and use it like any other Unity project
* For deployment, we just followed [mob-sakai process ](https://www.patreon.com/posts/25070968) and it worked like a charm

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
