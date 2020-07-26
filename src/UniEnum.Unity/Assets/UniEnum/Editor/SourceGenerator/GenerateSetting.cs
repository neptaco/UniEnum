namespace UniEnumUtils.SourceGenerator
{
    [System.Serializable]
    public class GenerateSetting
    {
        public string Namespace = "UniEnumUtils";
        public string OutputDir = "Assets/Plugins/UniEnum/Generated";
        
        public bool generateSceneValues;
        public bool generateSortingLayerValues;
        public bool generateLayerValues;
        public bool generateTagValues;
       
    }
}
