using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagement.Data
{
    public class MemberService
    {
        private string _dbPath;
        public string StatusMessage { get; set; }
        private SQLiteAsyncConnection conn;

        public MemberService(string dbPath)
        {
            _dbPath = dbPath;
        }

        private async Task InitAsync()
        {
            // Don't create the database if it already exists
            if (conn != null)
                return;

            // Create the database and Member table if not already created
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Member>();
        }

        public async Task<List<Member>> GetMembersAsync()
        {
            await InitAsync();
            return await conn.Table<Member>().ToListAsync();
        }

        public async Task<Member> CreateMemberAsync(Member member)
        {
            await InitAsync();
            await conn.InsertAsync(member);
            // Return the member object with the auto-incremented Id populated
            return member;
        }

        public async Task<Member> UpdateMemberAsync(Member member)
        {
            await InitAsync();
            await conn.UpdateAsync(member);
            // Return the updated member object
            return member;
        }

        public async Task<Member> DeleteMemberAsync(Member member)
        {
            await InitAsync();
            await conn.DeleteAsync(member);
            return member;
        }
    }
}
