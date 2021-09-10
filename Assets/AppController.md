AppController is a game object that persists through all scenes
Implemented as a singleton (through AppController.cs)

## Accessing AppController
Since the [AppController.cs](Assets/AppController/AppController.cs) inherits from the Singleton class (TODO - make link), it can be referenced by AppController.AppController.Instance (namespace.singleton.instance).
To then get the attached scripts just use ...Instance.GetComponent().

## Scripts
The following are all contained in AppController namespace

### [AppController.cs](Assets/AppController/AppController.cs)
Handles the persistance of the object.
Really just a container that inherits from Singleton.cs (Util)


### [AppModel.cs](Assets/AppController/AppModel.cs)
Want to pass information between scenes? Use this.
Is really just a container for scene models: classes containing information relevant to certain scenes. For example GameModel contains whether the menu should be skipped or not.



