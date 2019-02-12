namespace * yaskawa.ext.api
namespace csharp Yaskawa.Ext.API


typedef i64 ExtensionID
typedef i64 ControllerID
typedef i64 PendantID


exception InvalidID {
//    1: string message;
}

exception IllegalArgument {
    1:required string msg;
}

union Any {
    1: bool   bValue;
    2: i64    iValue;
    3: double rValue;
    4: string sValue;
}

struct Version {
    1: i16 nmajor;
    2: i16 nminor;
    3: i16 npatch;
    4: optional string release;
    5: optional string build;
}


enum LoggingLevel {
    Debug = 0, 
    Info = 1, 
    Warn = 2, 
    Critical = 3 
}

/**
  The Extension API.

  Use this interface to initially register the extension with the main pendant
  API Service and obtain handle IDs to the Controller and Pendant services.

  Note in this function-level documentation, functions of the Controller Service
  take an initial ControllerID parameter, Pendant Service functions take an initial PendantID etc.  
  However, if you are using a Yaskawa supplied client library these may be wrapped as 
  object methods and hence the initial id should be omitted.
*/
service Extension
{
    /** Version of API the service implements */
    Version apiVersion();

    /** Register extension with Smart Pendant API service.  
        Extension must exist in the extension database (i.e. through installation)
    */
    ExtensionID registerExtension(1:string canonicalName,
                                  2:string launchKey,
                                  3:Version version,
                                  4:string vendor,
                                  5:set<string> supportedLanguages)
                        throws (1:IllegalArgument e);

    void unregisterExtension(1:ExtensionID id) throws (1:InvalidID e);

    /** Indicate liveliness 
        API service will automatically unregister extensions that are unresponsive for some period.
        If extension is not regularly calling events(), call ping() to indicate the extension is operational.
    */
    void ping(1:ExtensionID id) throws (1:InvalidID e);

    /** Obtain ID handle for Robot Conroller API */
    ControllerID controller(1:ExtensionID id) throws (1:InvalidID e);

    /** Obtain ID handle for Pendant UI API */
    PendantID pendant(1:ExtensionID id) throws (1:InvalidID e);

    /** Log message to standard pendant logging facility 
        Visible to end-users upon plain-text log file export.
        Note that Debug level logging is ignored unless in Developer access level.
    */
    oneway void log(1:ExtensionID id, 2:LoggingLevel level, 3:string message);
}






//
// Pendant Service (UI)

enum PendantEventType {
    Startup = 0,
    Shutdown,
    SwitchedScreen,
    PopupOpened,
    PopupClosed,
    UtilityOpened,
    UtilityClosed,
    UtilityMoved,
    Clicked,
    Pressed,
    Released,
    TextEdited,

    Other = 16384
}

struct PendantEvent {
    1: required PendantEventType eventType;
    2: optional map<string,Any> props;
}

enum UtilityWindowWidth {
    HalfWidth = 0,
    FullWidth
}

enum UtilityWindowHeight {
    QuarterHeight = 0,
    HalfHeight,
    FullHeight
}

enum UtilityWindowExpansion {
    expandableNone = 0,
    expandableWidth = 1,
    expandableHeight = 2,
    expandableBoth = 3
}

enum IntegrationPoint {
    UtilityWindow = 0,
    NavigationPanel = 10,
    ProgrammingCommandBar = 20,
    ProgrammingHeaderBar = 30,
    SmartFrameJogPanelBottomCenter = 40
}

service Pendant
{
    /** Subscribe to specified set of Pendant service events.  May be called multiple times to add to subscription. */
    void subscribeEventTypes(1:PendantID p, 2:set<PendantEventType> types);

    /** Unsubscribe from specified set of Pendant service events. */
    void unsubscribeEventTypes(1:PendantID p, 2:set<PendantEventType> types);

    /** Obtain list of Pendant service events that have occured since last call */
    list<PendantEvent> events(1:PendantID p);

    /** Query the current UI language of the pendant interface.  
        Returns IETF language codes (RFCs 5646, 5645, 4647) of languages
        (typically ISO 693-1 code when region insignificant)
    */
    string currentLanguage(1:PendantID p);

    /* Query the current UI locale (which indicates the language & region) */
    string currentLocale(1:PendantID p);

    /** The UI screen currently shown to the pendant user */
    string currentScreenName(1:PendantID p);

    /** Register an Item type described using a YML source code string
        Returns a list of parsing errors (0 on success)
    */
    list<string> registerYML(1:PendantID p, 2:string ymlSource);

    /** Register an image file for later reference by filename (must be uniquely named, with .jpg or .png).
        Path to file may be supplied, but only filename part is used for referencing. 
        If file cannot be accessed by service, it will be locally read and registerImageData called instead.
    */
    void registerImageFile(1:PendantID p, 2:string imageFileName)
                          throws (1:IllegalArgument e);

    /** Register an image for later reference by name (must be uniquely named, with .jpg or .png extension) */
    void registerImageData(1:PendantID p, 2:binary imageData, 3:string imageName)
                          throws (1:IllegalArgument e);

    /** Register a Utility window with the UI.  
        For integtated windows, the itemType references a previously registered YML item instantiates for the window
        UI content.  For non-integtated (native) windows, the content should be displayed a the locations indicated
        by UtilityOpened and UtilityMoved events and hidden in response to a UtilityClosed event.
        A main menu entry will automatically be added to the pendant UI, for opening the utility window.
    */
    void registerUtilityWindow(1:PendantID p, 2:string identifier, 
                               3:bool intergated, 4:string itemType,
                               5:string menuItemName, 6:string windowTitle, 
                               7:UtilityWindowWidth widthFormat, 8:UtilityWindowHeight heightFormat,
                               9:UtilityWindowExpansion sizeExpandability)
                          throws (1:IllegalArgument e);

    void unregisterUtilityWindow(1:PendantID p, 2:string identifier)
                          throws (1:IllegalArgument e);
    

    /** Register UI content at the specified integration point in the pendant UI.
        The itemType should reference a YML item previouslt registered via registerYML(). 
    */
    void registerIntegration(1:PendantID p, 2:string identifier, 3:IntegrationPoint integrationPoint,
                             4:string itemType, 5:string buttonLabel, 6:string buttonImage)
                          throws (1:IllegalArgument e);

    void unregisterIntegration(1:PendantID p, 2:string identifier)
                          throws (1:IllegalArgument e);


    /** get property of an item by id */
    Any property(1:PendantID p, 2:string itemID, 3:string name)
                throws (1:IllegalArgument e);

    /** Set property of an item by id */
    void setProperty(1:PendantID p, 2:string itemID, 3:string name, 4:Any value)
                     throws (1:IllegalArgument e);


    /** Show notice to user.
        Notices are automaticlly hidden after a short display period.
        Notice messages are logged, if log parameter if provided, that will be logged instead of title & message.
    */
    oneway void notice(1:PendantID p, 2:string title, 3:string message, 4: string log);

    /** Show error to user.
        Errors should only indicate inportant situations that the user must be aware of and for which deliberate
        acknowledgement is required before proceeding.  Typically, some action will be required to correct the situation.
        Errors are displayed until dismissed by the user.
        Error messages are logged, if log parameter if provided, that will be logged instead of title & message.
    */
    oneway void error(1:PendantID p, 2:string title, 3:string message, 4: string log);


    /** Display modal pop-up dialog.  Typically, Yes/No, although negativeOption can be omitted 
        The identifier can be used to associate the corresponding PopupOpened & PopupClosed events triggered by
        user positive/negative selection or automatic dismissal/cancellation - for example is screen switched, alarm etc.
     */
    void popupDialog(1:PendantID p, 2:string identifier, 3:string title, 4:string message, 5:string positiveOption, 6:string negativeOption)
                     throws (1:IllegalArgument e);
    /** Cancel an open popup dialog.  If the dialog has a negative option, behaves as if user selected it, otherwise
        no event is generated */
    void cancelPopupDialog(1:PendantID p, 2:string identifier);
}




//
// Controller Service

typedef i32 RobotIndex
typedef i32 ToolIndex

enum ControllerEventType {
    Connected = 0,
    RobotModel, // TODO: move to Robot?
    ExclusiveControl,
    CycleTime,
    PowerOnTime,
    ServoOnTime,
    EnabledOptionsChanged,
    OperationMode,
    ServoState,
    PlaybackState,
    SpeedOverride,
    ActiveTool,
    AlarmActive,
    ActiveAlarmsChanged,
    RestartRequired,
    EStopEngaged,
    EnableSwitchActive,
    RemoteMode,
    JoggingActive,
    JoggingSpeedChanged,
    JoggingModeChanged,
    RobotTCPPosition, // TODO: move to robot
    BrakeRelease, // TODO: robot?
    SoftLimitRelease,
    SelfInterferenceRelease
    AllLimitsRelease,
    ParametersChanged,
    PredefinedPositionsChanged,
    FeatureAvailabilityChanged,
    JointLimitsChanged,
    JointMotorPulseDegreeRatioChanged,
    FunctionalSafetyHardwareAvailable,
    NetworkInterfacesChanged,

    CurrentRobot,

    JobTagsChanged,
    JobListChanged,
    JobStackChanged,
    CurrentJob,
    DefaultJob,
    ToolsChanged,
    ToolIOsChanged,
    UserFramesChanged,
    ZonesChanged,
    SafetyRobotRangeLimitDataChanged, // Robot?
    SafetyAxisSpeedMonitorDataChanged, // Robot?
    SafetySpeedLimitDataChanged, // Robot?
    SafetyExternalForceMonitorFileChanged, // Robot? Name?
    SafetyIOListChanged,

    VariablesChanged, // allow sub by variable list, like watch?
    VariableNamesChanged,
    IONamesChanged,
    IOValueChanged
}

struct ControllerEvent {
    1: required ControllerEventType eventType;
    2: optional map<string,Any> props;
}

enum OperationMode { Automatic=0, Manual=1 }
enum ServoState { Off=0, Ready=1, On=2 }
enum PlaybackState { Run=0, Hold=1, Idle=2 }


enum ControlGroupType {
    Robot = 0,
    Base,
    Station,
    Combined = 254,
    None = 255
}

struct SimpleControlGroup {
    1: ControlGroupType type;
    2: optional i8 index;
}

struct CombinedControlGroup {
    1: list<SimpleControlGroup> groups;
    2: optional SimpleControlGroup master;
}

struct ControlGroup {
    1: ControlGroupType type;
    2: i8 number;
    3: optional SimpleControlGroup sgroup;
    4: optional CombinedControlGroup cgroup;
}



/** Interface to Robot Controllers 

    In general, a pendant may operate in connected or disconnected states.  When connected to a Robot Controller
    it may be monitoring or not have exclusive control (i.e. not be the single-point-of-control).

    However, typically, once an extension is running, the pendant is connected to the controller and 
    is the single-point-of-control. 

    I/O:

        Controllers may support mutiple types of Input/Output, including physical digital wires,
        network I/O with various protocols, virtual controller states etc.  
        I/O can be referenced via two different address spaces: 
         - User-facing input, output and group numbers, referenced in the pendant interface 
           or user jobs/programs.  
         - Logical I/O numeric addresses, which cover inputs and outputs of all types, 
        The mapping from user input & output numbers to the underlying Logical I/O address is
        configurable (though often setup during manufacturing infrequently changed).

        Inputs & Outputs represent single bits.  An I/O group is a set of 8 inputs/outputs (i.e. a byte).
        1-4 groups can be read & written together, represend as 1-4 bytes (8,16,24 or 32 bits).

        Fetching multiple I/O bits synchronously fequently via the functions below is inefficient 
        and should be avoided.  Prefer adding relevant I/O numbers to the monitored set and reacting
        to IOValueChanged events instead.


    Control Groups:

        A ControlGroup represents a set of axes that can be controlled - such as a robot, an external
        base (e.g. a rail) or a station (e.g. a part fixture able to rotate and tilt).

        In many cases, the only control group defined is R1 - a single robot connected to the controller.

        Custom control groups can be configured on the controller, by combining simple groups - for example,
        by combining a robot and a base and station, or two robots etc.  
        
        In addition, the controller may support coordinated motion between a master & slave control group, 
        such that one will move in response to commanded motions of the other.  For example, a control 
        group including a robot and a station where the station is the master, allows motions commanding
        the station (for example holding a part) to cause the robot to move in order to maintain the same
        relationship between the robot tool and the part on the station.

        For example, R1+R2+B2+S1:S1 designates a combined control group, consisting of the simple control
        groups corresponding to Robot 1, Robot 2 incuding a Base, and Station 1.  Additionally, Station 1
        is the master control group.

*/
service Controller
{
    /** Connect to the specified Robot Controller (by IP adress or hostname if DNS available)
        Typically, the pendant will already be connected to a controller when extensions are started,
        so calling connect() is not required.
    */
    void connect(1:ControllerID c, 2:string hostName);

    /** Disconnect from the connected controller.  This leaves the pendant in the 'disconnected' state. 
        When disconnected, many functions are unavailable or will return default values.
    */
    void disconnect(1:ControllerID c);

    /** Subscribe to the specified events, if not already.
        Note: If using a Yaskawa supplied client library with event consumer callback support,
              registering an event consumer callback will automatically subscribe to the appropriate event.
    */
    void subscribeEventTypes(1:ControllerID c, 2:set<ControllerEventType> types);

    /** Unsubscribe from the specified events.  
        If called directly, this may causes event consumers for the events not to be called.
    */
    void unsubscribeEventTypes(1:ControllerID c, 2:set<ControllerEventType> types);

    /** Poll the API Service for pending events.
        Note: If using a Yaskawa supplied client library, this does not need to be called explicitly.        
    */
    list<ControllerEvent> events(1:ControllerID c);

    /** Returns true if the pendant is connected to a robot controller */
    bool connected(1:ControllerID c);
    /** Returns the hostname or IP address of the robot controller to which the pendant is connected, if any */
    string connectedHostName(1:ControllerID c);

    /** The software version string of the robot controller system software. */
    string softwareVersion(1:ControllerID c);

    /** Returns true if the pendant is only monitoring the robot controller to which it is connected.  This
        implies that no functions that modify the controller and/or robot state will succeed.
    */
    bool monitoring(1:ControllerID c);
    //void setMonitoring(1:ControllerID c, 2:bool monitor);

    //bool acquireExclusiveControl(1:ControllerID c);
    //void releaseExclusiveControl(1:ControllerID c);
    /** Returns true if this pendant is the single-point-of-control for the connected Robot Controller.
        If not, most functions that modify the controller and/or robot state will fail.
    */
    bool haveExclusiveControl(1:ControllerID c);
    //string noExclusiveControlReason(1:ControllerID c);


    /** Current operation mode of the controller
          Automatic (aka Play) - running jobs
          Manual (aka Teach) - for editing jobs, teaching points, jogging, setup etc.
    */
    OperationMode operationMode(1:ControllerID c);

    /** Are the servo drives engaged? 
        On - yes, robot(s) are being actively controlled
        Off - no.  Typically brakes are engaged (unless brake-release engaged)
        Ready - ready to engage servos.  Typically requires operator to use servo enable switch.
    */
    ServoState servoState(1:ControllerID c);


    /** Indicates if a job us running or stopped. 
        Run - jobs are running (robot may be moving)
        Held - jobs were running but have been held/paused.
        Idle - no jobs are running
    */
    PlaybackState playbackState(1:ControllerID c);


    /** Name of the current job (e.g. job being run or edited) 
        Empty if none.
    */
    string currentJob(1:ControllerID c);

    /** Name of the default (aka master) job.  Empty if no default job designated */
    string defaultJob(1:ControllerID c);

    
    /**    Return input number of given input name */
    i32 inputNumber(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);
    /** Return input group number for group beginning with given input name */
    i32 inputGroupNumber(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);
    /** Return output nunber of given output name */
    i32 outputNumber(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);
    /** Return output group number for group beginning with given input name */
    i32 outputGroupNumber(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);

    /** Return name of specified input number */
    string inputName(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Return name of specified output number */
    string outputName(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Set name of specified input (asynchronously) */
    oneway void setInputName(1:ControllerID c, 2:i32 num, 3:string name);
    /** Set name of specified output (asynchronously) */
    oneway void setOutputName(1:ControllerID c, 2:i32 num, 3:string name);

    /** Start monitoring specified input */
    void monitorInput(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Start monitoring all inputs in given input group */
    void monitorInputGroups(1:ControllerID c, 2:i32 groupNum, 3:i32 count) throws (1:IllegalArgument e);
    /** Start monitoring specified output */
    void monitorOutput(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Start monitoring all outputs in given output group */
    void monitorOutputGroups(1:ControllerID c, 2:i32 groupNum, 3:i32 count) throws (1:IllegalArgument e);

    /** Stop monitoring specified input */
    void unmonitorInput(1:ControllerID c, 2:i32 num);
    /** Stop monitoring all inputs in specified group */
    void unmonitorInputGroups(1:ControllerID c, 2:i32 groupNum, 3:i32 count);
    /* Stop monitoring specified output */
    void unmonitorOutput(1:ControllerID c, 2:i32 num);
    /* Stop monitoring all outputs in specified group */
    void unmonitorOutputGroups(1:ControllerID c, 2:i32 groupNum, 3:i32 count);

    /** Return value of given input */
    bool inputValue(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Return values of input groups from specified group number (upto 4 contiguous groups/bytes, from least significant byte) */
    i32 inputGroupsValue(1:ControllerID c, 2:i32 groupNum, 3:i32 count) throws (1:IllegalArgument e);

    /** Return the value of given output */
    bool outputValue(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Return values of output groups from specified group number (upto 4 contiguous groups/bytes) */
    i32 outputGroupsValue(1:ControllerID c, 2:i32 groupNum, 3:i32 count) throws (1:IllegalArgument e);

    /** Set the value of the specified output number */
    oneway void setOutput(1:ControllerID c, 2:i32 num, 3:bool value);
    /** Set the values of the outputs in the specified contigous output groups (upto 4 contiguous groups/bytes) */
    oneway void setOutputGroups(1:ControllerID c, 2:i32 groupNum, 3:i32 count, 4:i32 value);

    /** Return the logical IO address of the named input */
    i32 inputAddress(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);
    /** Return the logical IO address of the given input number */
    i32 inputAddressByNumber(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);
    /** Return the logical IO address of the named output */
    i32 outputAddress(1:ControllerID c, 2:string name) throws (1:IllegalArgument e);
    /** Return the logical IO address of the given output number */
    i32 outputAddressByNumber(1:ControllerID c, 2:i32 num) throws (1:IllegalArgument e);

    /** Start monitoring a logical IO address.  Will generate IOValueChanged events */
    void monitorIOAddress(1:ControllerID c, 2:i32 address) throws (1:IllegalArgument e);
    /** Stop monitoring a logical IO address. (events for address may still be generated if it corresponds to a monitored input or output) */
    void unmonitorIOAddress(1:ControllerID c, 2:i32 address);

    /** Return the value of the given input by logcial IO address */
    bool inputAddressValue(1:ControllerID c, 2:i32 address) throws (1:IllegalArgument e);
    /** Return the value of the given output by logcial IO address */
    bool outputAddressValue(1:ControllerID c, 2:i32 address) throws (1:IllegalArgument e);
    /** Set the value of the given output by logical IO address */
    oneway void setOutputAddress(1:ControllerID c, 2:i32 address, 3:bool value);


    /* Return the list of control groups configured on the controller.
       If only one robot is connected to the controller, this will return a single element,
       containing the simple control group representing the robot.
    */
    list<ControlGroup> controlGroups(1:ControllerID c);

    /** Returns the index of the currently active control group. */
    i8 currentControlGroup(1:ControllerID c);

    /* Returns the number of robots connected to the controller */
    i8 robotCount(1:ControllerID c);

    /* Returns the index of the currently active robot. 
       Note: index is 0-based, but in the UI the first robot is Robot 1.
    */
    RobotIndex currentRobot(1:ControllerID c);

}

service Robot
{
    /** The model string of this robot */
    string model(1:RobotIndex r);

    /** Number of degrees-of-freedom / axes */
    i32 dof(1:RobotIndex r);

    /** Does this robot support force limiting? (collaborative robot?) */
    bool forceLimitingAvailable(1:RobotIndex r);

    /** Is force limiting currently active? (i.e. PFL - Power & Force Limiting) */
    bool forceLimitingActive(1:RobotIndex r);

    /** Is the robot stopped due to an over-limit event? */
    bool forceLimitingStopped(1:RobotIndex r);

    /** Is an end-of-arm switch box installed? */
    bool switchBoxAvailable(1:RobotIndex r);

    /** Index of the currently active tool */
    ToolIndex activeTool(1:RobotIndex r);

    /** Set the currently active tool */
    void setActiveTool(1:RobotIndex r, 2:ToolIndex tool);

}



//service Job
//{
//}

//service InformJob extends Job
//{
//    i32 lineCount(),
//
//}
