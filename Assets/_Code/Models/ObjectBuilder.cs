using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectBuilder
{
    public static MoviesItemModel BuildModel(JSONNode jsonObject)
    {
        MoviesItemModel _responseModel = new MoviesItemModel();
        _responseModel.Id = int.Parse(jsonObject["id"]);
        _responseModel.Name = jsonObject["name"];
        _responseModel.Year = int.Parse(jsonObject["year"]);
        _responseModel.Director = jsonObject["director"];
        _responseModel.LeadActor = jsonObject["leadActor"];
        _responseModel.SupportActor = jsonObject["supportActor"];
        _responseModel.CriticScore = int.Parse(jsonObject["criticScore"]);
        _responseModel.AudienceScore = int.Parse(jsonObject["audienceScore"]);
        _responseModel.Synopsis = jsonObject["synopsis"];
        _responseModel.Budget = int.Parse(jsonObject["budget"]);
        _responseModel.Revenue = int.Parse(jsonObject["revenue"]);

        return _responseModel;
    }
}
