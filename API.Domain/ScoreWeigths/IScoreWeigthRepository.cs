﻿using Domain.SportMen;

namespace Domain.ScoreWeigths
{
	public interface IScoreWeigthRepository
	{
		Task AddWeigthsAsync(ScoreWeigth scoreWeigth);
	}
}
