namespace CivaGame
{
    public interface ICreature
    {
        string GetImageFileName();
        int GetDrawingPriority();
        CreatureCommand Act(int x, int y);
    }
}
