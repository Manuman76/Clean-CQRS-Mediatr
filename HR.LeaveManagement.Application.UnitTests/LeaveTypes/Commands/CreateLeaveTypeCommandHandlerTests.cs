using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly CreateLeaveTypeDto _leaveTypeDto;
    private readonly CreateLeaveTypeCommandHandler _handler;
    
    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();

        _leaveTypeDto = new CreateLeaveTypeDto
        {
            DefaultDays = 15,
            Name = "Test DTO"
        };

        _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
    }

    [Fact]
    public async Task CreateLeaveType()
    {
        var leaveTypesCountBefore = _mockRepo.Object.GetAll().Result.Count;
        
        var result = await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto },
            CancellationToken.None);

        var leaveTypesCount = _mockRepo.Object.GetAll().Result.Count;

        result.ShouldBeOfType<int>();
        (leaveTypesCount - leaveTypesCountBefore).ShouldBe(1);
    }

    [Fact]
    public async Task Invalid_LeaveType_Added()
    {
        var leaveTypesCountBefore = _mockRepo.Object.GetAll().Result.Count;

        _leaveTypeDto.DefaultDays = -1;

        ValidationException ex = await Should.ThrowAsync<ValidationException>(async () =>
            await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _leaveTypeDto },
                CancellationToken.None));

        var leaveTypes = await _mockRepo.Object.GetAll();
        leaveTypes.Count.ShouldBe(leaveTypesCountBefore);
    }
}