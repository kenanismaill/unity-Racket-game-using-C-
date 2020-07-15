using System;

[Serializable]
public class GameData
{
    public float top;
    public float oyuncuXpos;
    public float oyuncuYpos;
    public int skor;

    public GameData(float _top, float _oyuncuXpos, float _oyuncuYpos, int _skor)
    {
        this.top = _top;
        this.oyuncuXpos = _oyuncuXpos;
        this.oyuncuYpos = _oyuncuYpos;
        this.skor = _skor;
    }
    
}
