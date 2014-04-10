public interface IReportBuilder
public abstract class BaseReportBuilder
public class HtmlReportBuilder : BaseReportBuilder, IReportBuilder
public class CsvReportBuilder : BaseReportBuilder, IReportBuilder

public abstract class BaseReportBuilder
    {
        protected string Content { get; set; }
 
        public virtual void Save(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, Content);
            }
            catch (Exception exception)
            {
                Log.ErrorFormat("BaseReportBuilder.Save() throw exception=<{0}>, filePath=<{1}>", exception, filePath);
            }
        }
    }