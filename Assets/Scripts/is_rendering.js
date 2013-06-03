public var isRendering:boolean=false;
private var lastTime:float=0;
private var curtTime:float=0;
 
function Update()
{
    isRendering=curtTime!=lastTime?true:false;
    lastTime=curtTime;
    if (!isRendering) {
    	Debug.Log('dfd');
    }
}
 
function OnWillRenderObject()
{
    curtTime=Time.time;
}