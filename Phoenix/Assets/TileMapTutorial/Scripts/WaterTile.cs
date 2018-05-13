using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterTile : Tile
{
    [SerializeField]
    private Sprite[] _waterSprites;
    [SerializeField]
    private Sprite _preview;

    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                Vector3Int nPos = new Vector3Int(position.x + x, position.y + y, position.z);
                if (HasWater(tilemap, nPos))
                {
                    tilemap.RefreshTile(nPos);
                }
            }
        }
    }

    private bool HasWater(ITilemap tilemap, Vector3Int position)
    {
        return tilemap.GetTile(position) == this;
    }

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        StringBuilder composition = new StringBuilder(8);
        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                if (x != 0 || y != 0)
                    composition.Append(HasWater(tilemap, new Vector3Int(position.x + x, position.y + y, position.z))
                        ? 'W'
                        : 'E');
            }
        }
        int randomVal = Random.Range(0, 100);

        if (randomVal < 15)
        {
            tileData.sprite = _waterSprites[46];
        }
        else if (randomVal >= 15 && randomVal < 35)
        {

            tileData.sprite = _waterSprites[48];
        }
        else
        {
            tileData.sprite = _waterSprites[47];
        }



        if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[0];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[5] == 'W' &&
                 composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[1];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[5] == 'E' &&
                 composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[2];
        }
        else if (composition[0] == 'W' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[5] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[3];
        }
        else if (composition[0] == 'W' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[4];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[5];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[5] == 'W' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[6];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'W' &&
                 composition[6] == 'W' && composition[7] == 'W')
        {
            tileData.sprite = _waterSprites[7];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[6] == 'W' &&
                 composition[5] == 'E' && composition[7] == 'W')
        {
            tileData.sprite = _waterSprites[8];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'W' &&
                 composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = _waterSprites[9];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'W' && composition[5] == 'E' &&
                 composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = _waterSprites[10];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'W' &&
                 composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[11];
        }
        else if (composition[0] == 'W' && composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'W' &&
                 composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[12];
        }
        else if (composition[0] == 'W' && composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'W' &&
                 composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[13];
        }
        else if (composition[0] == 'W' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[5] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[14];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'W' &&
                 composition[4] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[15];
        }
        else if (composition[0] == 'E' && composition[1] == 'W' && composition[3] == 'W' && composition[4] == 'E' &&
                 composition[5] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[16];
        }
        else if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'W' &&
                 composition[7] == 'W')
        {
            tileData.sprite = _waterSprites[17];
        }
        else if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'W' && composition[6] == 'W' &&
                 composition[7] == 'E')
        {
            tileData.sprite = _waterSprites[18];
        }
        else if (composition[1] == 'W' && composition[2] == 'W' && composition[4] == 'W' && composition[3] == 'E' &&
                 composition[6] == 'W' && composition[7] == 'W')
        {
            tileData.sprite = _waterSprites[19];
        }
        else if (composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'E' && composition[4] == 'W' &&
                 composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = _waterSprites[20];
        }
        else if (composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'E' && composition[4] == 'W' &&
                 composition[6] == 'W' && composition[7] == 'W')
        {
            tileData.sprite = _waterSprites[21];
        }
        else if (composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'E' && composition[4] == 'W' &&
                 composition[6] == 'W' && composition[7] == 'E')
        {
            tileData.sprite = _waterSprites[22];
        }
        else if (composition[1] == 'W' && composition[2] == 'W' && composition[3] == 'E' && composition[4] == 'W' &&
                 composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[23];
        }
        else if (composition[1] == 'W' && composition[2] == 'E' && composition[3] == 'E' && composition[4] == 'W' &&
                 composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[24];
        }
        else if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[25];
        }
        else if (composition[1] == 'E' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[26];
        }
        else if (composition[1] == 'W' && composition[3] == 'E' && composition[4] == 'E' && composition[6] == 'W')
        {
            tileData.sprite = _waterSprites[27];
        }
        else if (composition[1] == 'E' && composition[4] == 'W' && composition[3] == 'W' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[28];
        }
        else if (composition[1] == 'E' && composition[3] == 'E' && composition[6] == 'E' && composition[4] == 'W')
        {
            tileData.sprite = _waterSprites[29];
        }
        else if (composition[1] == 'E' && composition[3] == 'W' && composition[4] == 'E' && composition[6] == 'E')
        {
            tileData.sprite = _waterSprites[30];
        }
        else if (composition.ToString() == "EWWWWEWW")
        {
            tileData.sprite = _waterSprites[31];
        }
        else if (composition.ToString() == "EWEWWWWE")
        {
            tileData.sprite = _waterSprites[32];
        }
        else if (composition.ToString() == "EWEWWWWW")
        {
            tileData.sprite = _waterSprites[33];
        }
        else if (composition.ToString() == "WWWWWEWW")
        {
            tileData.sprite = _waterSprites[34];
        }
        else if (composition.ToString() == "WWEWWWWE")
        {
            tileData.sprite = _waterSprites[35];
        }
        else if (composition.ToString() == "WWWWWWWE")
        {
            tileData.sprite = _waterSprites[36];
        }
        else if (composition.ToString() == "EWWWWWWW")
        {
            tileData.sprite = _waterSprites[37];
        }
        else if (composition.ToString() == "WWEWWWWW")
        {
            tileData.sprite = _waterSprites[38];
        }
        else if (composition.ToString() == "EWWWWWWE")
        {
            tileData.sprite = _waterSprites[39];
        }
        else if (composition.ToString() == "EWWWWEWE")
        {
            tileData.sprite = _waterSprites[40];
        }
        else if (composition.ToString() == "WWWWWEWE")
        {
            tileData.sprite = _waterSprites[41];
        }
        else if (composition.ToString() == "WWEWWEWW")
        {
            tileData.sprite = _waterSprites[42];
        }
        else if (composition.ToString() == "EWEWWEWW")
        {
            tileData.sprite = _waterSprites[43];
        }
        else if (composition.ToString() == "WWEWWEWE")
        {
            tileData.sprite = _waterSprites[44];
        }
        else if (composition.ToString() == "EWEWWEWE")
        {
            tileData.sprite = _waterSprites[45];
        }
    }
#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/WaterTile")]
    public static void CreateWaterTile()
    {
        string path =
            EditorUtility.SaveFilePanelInProject("Save WaterTile", "New WaterTile", "asset", "Save WaterTile",
                "Assets");
        if (path == "")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<WaterTile>(), path);
    }
#endif
}
