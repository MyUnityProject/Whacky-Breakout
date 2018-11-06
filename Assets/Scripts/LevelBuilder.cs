using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {

    [SerializeField]
    GameObject paddle;

    [SerializeField]
    GameObject stdBlock;
    [SerializeField]
    GameObject bonusBlock;
    [SerializeField]
    GameObject freezeBlock;
    [SerializeField]
    GameObject speedBlock;

    int blocksHit = 0;
    int numberofBlocks = 0;

    float blockHeight;
    float blockWidth;
	// Use this for initialization
	void Start () {
        Instantiate(paddle, new Vector3(0, -4, 0),new Quaternion(0,0,0,0));
        GetBlockDemension();
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < Mathf.Abs(ScreenUtils.ScreenLeft - ScreenUtils.ScreenRight) / blockWidth - 1; i++)
            {
                Vector2 location = new Vector2(ScreenUtils.ScreenLeft + (i+1) * blockWidth, ScreenUtils.ScreenTop - (j+1) * blockHeight);
                PlaceBlock(location);
            }

        }
        numberofBlocks = 3 * (int)(Mathf.Abs(ScreenUtils.ScreenLeft - ScreenUtils.ScreenRight) / blockWidth );
        EventManager.AddPointListener(BlockHit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void GetBlockDemension()
    {
        GameObject tempBlock = Instantiate(stdBlock, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        Vector2 blocksize = tempBlock.GetComponent<BoxCollider2D>().size;
        blockWidth = blocksize.x*0.7f;
        blockHeight = blocksize.y*0.7f;
        Destroy(tempBlock);
    }

    void PlaceBlock(Vector2 location)
    {
        int randomNumber = Random.Range(0, 100);

        if (randomNumber < ConfigurationUtils.StdBlockChance)
            Instantiate(stdBlock, location, new Quaternion(0, 0, 0, 0));
        else if (randomNumber >= ConfigurationUtils.StdBlockChance && randomNumber < ConfigurationUtils.BonusBlockChance)
            Instantiate(bonusBlock, location, new Quaternion(0, 0, 0, 0));
        else if (randomNumber >= ConfigurationUtils.BonusBlockChance && randomNumber < ConfigurationUtils.FreezeBlockChance)
            Instantiate(freezeBlock, location, new Quaternion(0, 0, 0, 0));
        else
            Instantiate(speedBlock, location, new Quaternion(0, 0, 0, 0));

    }

    public void BlockHit(int unused)
    {
        blocksHit += 1;
        if (blocksHit >= numberofBlocks)
            MenuManager.GoToMenu(MenuName.EndGameMenu);
    }
}
