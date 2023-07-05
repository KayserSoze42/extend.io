this.didJump <- false;
this.isFalling <- false;
this.togglePause <- false;
this.StartJumpPosition <- null; 
this.EndJumpPosition <- null;
this.distance <- null;

function PreJump() 
{
	
	if (!Entities.FindByName(null, "jumpinTimer")) {
	
		printl("Jumpin' Jack Flash");
	
		local jumpinTimer = null;
		jumpinTimer = Entities.CreateByClassname("logic_timer");
		EntFireByHandle(jumpinTimer, "addoutput", "targetname jumpinTimer", 0.02, null, null);
	
	}
	
	EntFire("jumpinTimer", "addoutput", "refiretime 0.05");
	EntFire("jumpinTimer", "addoutput", "startdisabled 0");
	EntFire("jumpinTimer", "addoutput", "UseRandomTime 0");
	EntFire("jumpinTimer", "addoutput", "ontimer jumpinTimer,RunScriptCode,JumpThink()");
	EntFire("jumpinTimer", "enable");
	
	printl("done")

}

function JumpThink()
{
	if(!togglePause) {
	
		local playerEntity, playerVelocity;
		
		playerVelocity = [];

		playerEntity = Entities.FindByClassname(null, "player");
		
		playerVelocity = playerEntity.GetVelocity().z;
		
		if (!didJump){
		
			if (playerVelocity != 0){
		
				didJump = true;
				
				StartJumpPosition = playerEntity.GetOrigin();
			}
		
		} else {
		
			if (!isFalling){
			
				if(playerVelocity < 0){
				
					isFalling = true;
				
				}
			
			} else {
			
				if(playerVelocity == 0){
				
					EndJumpPosition = playerEntity.GetOrigin();
					
					didJump = false;
					isFalling = true;
					
					distance = sqrt(pow(EndJumpPosition.x - StartJumpPosition.x, 2) + pow(EndJumpPosition.y - StartJumpPosition.y, 2) + pow(EndJumpPosition.z - StartJumpPosition.z, 2));
					ScriptPrintMessageChatAll("Jump Distance: " + distance.tostring());
					
					StartJumpPosition = null;
					EndJumpPosition = null;
				
				}
			
			}
		
		}
	
	}
	
}

function TogglePause(){

	togglePause = !togglePause;

}

PreJump();
EntFire("jumpinTimer", "enable");



