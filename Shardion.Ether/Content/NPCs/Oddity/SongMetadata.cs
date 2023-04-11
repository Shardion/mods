namespace Shardion.Ether.Content.NPCs.Oddity
{
    public class SongMetadata
    {
        public virtual float BPM => 0;

        public virtual void Update()
        {

        }
    }

    public class OddityNormalSongMetadata : SongMetadata
    {
        public override float BPM => 187;
    }

    public class OddityEXSongMetadata : SongMetadata
    {
        public override float BPM => 210; // TODO: Decide which song this is going to be (and change 210 if it doesn't end up being *that one*)
    }
}