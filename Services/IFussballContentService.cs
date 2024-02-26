namespace TestProject.Services;

public interface IFussballContentService
{
    void CreateContent<T>(string nodeName, int parentId, string contentType, T contentData = default);
    void CreateContent();
}