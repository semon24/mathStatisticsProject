﻿using MathStatisticsProject.Data;
using MathStatisticsProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MathStatisticsProject.Repositories
{
    public class HomeworkRepository
    {
        private readonly Context db;

        public HomeworkRepository(Context db)
        {
            this.db = db;
        }

        public async Task<List<Homework>> GetAllHomeworksAsync()
        {
            return await db.Homeworks.OrderBy(h => h.Id).ToListAsync();
        }

        public async Task<Homework> GetHomeworkByIdAsync(int id)
        {
            return await db.Homeworks.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<bool> AddHomeworkAsync(int id, Models.Type type, int number, DateTime send, Status status, int studentId, Message message)
        {
            var homework = new Homework
            {
                Id = id,
                Type = type,
                Number = number,
                Send = send,
                Status = status,
                StudentId = studentId,
                Message = message
            };

            await db.Homeworks.AddAsync(homework);
            return await db.SaveChangesAsync() >= 0;
        }

        // CR: куча параметров у метода. А если модель расширится(добавится еще поле?). Тогда нужно в объявлении метода
        // и во всех местах использования переписывать. Нужно передавать класс. И почитай про automapper(в проекте-референсе он есть)
        public async Task<bool> UpdateHomeworkAsync(int id, Models.Type type, int number, DateTime send, Status status, int studentId, Message message)
        {
            var homework = await db.Homeworks.FirstOrDefaultAsync(h => h.Id == id);
            if (homework == null)
                return false;

            homework.Id = id;
            homework.Type = type;
            homework.Number = number;
            homework.Send = send;
            homework.Status = status;
            homework.StudentId = studentId;
            homework.Message = message;

            db.Homeworks.Update(homework);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteHomeworkAsync(int homeworkId)
        {
            var homework = new Homework { Id = homeworkId };
            db.Homeworks.Attach(homework);
            db.Homeworks.Remove(homework);
            return await db.SaveChangesAsync() >= 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }
    }
}
