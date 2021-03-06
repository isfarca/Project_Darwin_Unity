using UnityEngine;

public class FlickeringLight : MonoBehaviour {

    private int flickerTimer, flickerAt, lightOffTimer, lightOffAt;
    //bool lightOn;
    private Light flickerLight;

    void Start() {
        flickerLight = this.GetComponent<Light>();
        lightOffAt = 3;
        FlickerOn();
	}
	
	void Update() {
        flickerTimer++;

        if (flickerTimer >= flickerAt)
        {
            FlickerOn();
        }

        if (flickerLight.enabled == true && lightOffTimer <= lightOffAt)
        {
            lightOffTimer++;
        }
        else if (flickerLight.enabled == true && lightOffTimer > lightOffAt)
        {
            FlickerOff();
        }
	}

    void FlickerOn()
    {
        //turn light on
        flickerLight.enabled = true;
        flickerTimer = 0;
        flickerAt = Random.Range(5, 50);
    }

    void FlickerOff()
    {
        //turn light off
        flickerLight.enabled = false;
        lightOffTimer = 0;
    }
}