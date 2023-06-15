﻿using SuperSprinter3000.WebUI.RazorPages.DataAccess.Entities;

namespace SuperSprinter3000.WebUI.RazorPages.DataAccess.Repositories;

public interface IUserStoriesRepository
{
    public IEnumerable<UserStory> GetAll();
    public UserStory? GetById(int id);
    public void Add(UserStory userStory);
    public void Update(UserStory userStory);
    public bool ExistsById(int id);
}