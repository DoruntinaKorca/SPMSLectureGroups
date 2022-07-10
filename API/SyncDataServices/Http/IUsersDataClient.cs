using Application.DTOs.LectureGroupDtos;
using System.Threading.Tasks;

namespace API.SyncDataServices.Http
{
	public interface IUsersDataClient
	{
		Task SendLectureGroupToUsers(RequestLectureGroupDto lectureGroup);
	}

}
