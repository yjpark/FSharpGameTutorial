using TiledSharp;

namespace Tank.Content {
    public static class Maps {
        private static TmxMap _First = null;
        public static TmxMap First {
            get {
                if (_First == null) {
                    _First = new TmxMap("Maps/First.tmx");
                }
                return _First;
            }
        }
    }
}